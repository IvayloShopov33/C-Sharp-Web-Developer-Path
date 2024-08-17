using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;

using Newtonsoft.Json;

using NetPay.Data;
using NetPay.Data.Models;
using NetPay.Data.Models.Enums;
using NetPay.DataProcessor.ImportDtos;

namespace NetPay.DataProcessor
{
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data format!";
        private const string DuplicationDataMessage = "Error! Data duplicated.";
        private const string SuccessfullyImportedHousehold = "Successfully imported household. Contact person: {0}";
        private const string SuccessfullyImportedExpense = "Successfully imported expense. {0}, Amount: {1}";

        public static string ImportHouseholds(NetPayContext context, string xmlString)
        {
            var output = new StringBuilder();
            var xmlSerializer = new XmlSerializer(typeof(HouseholdInputXmlModel[]), new XmlRootAttribute("Households"));
            var stringReader = new StringReader(xmlString);

            var households = (HouseholdInputXmlModel[])xmlSerializer.Deserialize(stringReader);
            var validHouseholds = new List<Household>();

            foreach (var currentHousehold in households)
            {
                if (!IsValid(currentHousehold))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                if (currentHousehold.Email != null && validHouseholds.Any(x => x.Email == currentHousehold.Email))
                {
                    output.AppendLine(DuplicationDataMessage);
                    continue;
                }

                if (validHouseholds.Any(x => x.ContactPerson == currentHousehold.ContactPerson ||
                    x.PhoneNumber == currentHousehold.PhoneNumber))
                {
                    output.AppendLine(DuplicationDataMessage);
                    continue;
                }

                var household = new Household
                {
                    ContactPerson = currentHousehold.ContactPerson,
                    Email = currentHousehold.Email ?? null,
                    PhoneNumber = currentHousehold.PhoneNumber,
                };

                validHouseholds.Add(household);
                output.AppendLine(string.Format(SuccessfullyImportedHousehold, household.ContactPerson));
            }

            context.Households.AddRange(validHouseholds);
            context.SaveChanges();

            return output.ToString().TrimEnd();
        }

        public static string ImportExpenses(NetPayContext context, string jsonString)
        {
            var output = new StringBuilder();
            var expenses = JsonConvert.DeserializeObject<ExpenseInputJsonModel[]>(jsonString);
            var validExpenses = new List<Expense>();

            foreach (var currentExpense in expenses)
            {
                if (!IsValid(currentExpense))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                if (!context.Households.Any(x => x.Id == currentExpense.HouseholdId) ||
                    !context.Services.Any(x => x.Id == currentExpense.ServiceId))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime dueDate;
                bool isDueDateValid = DateTime.TryParseExact(currentExpense.DueDate, "yyyy-MM-dd", CultureInfo
                    .InvariantCulture, DateTimeStyles.None, out dueDate);

                if (!isDueDateValid)
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var expense = new Expense
                {
                    ExpenseName = currentExpense.ExpenseName,
                    Amount = currentExpense.Amount,
                    DueDate = dueDate,
                    PaymentStatus = (PaymentStatus)Enum.Parse(typeof(PaymentStatus), currentExpense.PaymentStatus),
                    HouseholdId = currentExpense.HouseholdId,
                    ServiceId = currentExpense.ServiceId,
                };

                validExpenses.Add(expense);
                output.AppendLine(string.Format(SuccessfullyImportedExpense, expense.ExpenseName, expense.Amount.ToString("f2")));
            }

            context.Expenses.AddRange(validExpenses);
            context.SaveChanges();

            return output.ToString().TrimEnd();
        }

        public static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(dto, validationContext, validationResults, true);

            foreach (var result in validationResults)
            {
                string currvValidationMessage = result.ErrorMessage;
            }

            return isValid;
        }
    }
}