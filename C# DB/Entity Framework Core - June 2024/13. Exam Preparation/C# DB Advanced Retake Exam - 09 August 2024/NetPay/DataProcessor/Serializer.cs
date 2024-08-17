using System.Globalization;
using System.Xml.Serialization;

using Newtonsoft.Json;

using NetPay.Data;
using NetPay.Data.Models.Enums;
using NetPay.DataProcessor.ExportDtos;

namespace NetPay.DataProcessor
{
    public class Serializer
    {
        public static string ExportHouseholdsWhichHaveExpensesToPay(NetPayContext context)
        {
            var householdsWhichHaveExpensesToPay = context.Households
                .Where(x => x.Expenses.Any(y => y.PaymentStatus != PaymentStatus.Paid))
                .Select(x => new HouseholdOutputXmlModel
                {
                    ContactPerson = x.ContactPerson,
                    Email = x.Email,
                    PhoneNumber = x.PhoneNumber,
                    Expenses = x.Expenses
                        .Where(y => y.PaymentStatus != PaymentStatus.Paid)
                        .OrderBy(y => y.DueDate)
                        .ThenByDescending(y => y.Service.ServiceName.Length)
                        .ThenBy(y => y.Amount)
                        .Select(y => new ExpenseOutputXmlModel
                        {
                            ExpenseName = y.ExpenseName,
                            Amount = $"{y.Amount:f2}",
                            PaymentDate = y.DueDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                            ServiceName = y.Service.ServiceName,
                        })
                        .ToArray(),
                })
                .OrderBy(x => x.ContactPerson)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(HouseholdOutputXmlModel[]), new XmlRootAttribute("Households"));
            var stringWriter = new StringWriter();
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);
            xmlSerializer.Serialize(stringWriter, householdsWhichHaveExpensesToPay, namespaces);

            return stringWriter.ToString();
        }

        public static string ExportAllServicesWithSuppliers(NetPayContext context)
        {
            var servicesWithSuppliers = context.Services
                .Select(x => new ServiceOutputJsonModel
                {
                    ServiceName = x.ServiceName,
                    Suppliers = x.SuppliersServices
                        .Select(y => new SupplierOutputJsonModel
                        {
                            SupplierName = y.Supplier.SupplierName,
                        })
                        .OrderBy(y => y.SupplierName)
                        .ToArray(),
                })
                .OrderBy(x => x.ServiceName)
                .ToArray();

            return JsonConvert.SerializeObject(servicesWithSuppliers, Formatting.Indented);
        }
    }
}