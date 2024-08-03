using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;

using TravelAgency.Data;
using TravelAgency.Data.Models;
using TravelAgency.DataProcessor.ImportDtos;

namespace TravelAgency.DataProcessor
{
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data format!";
        private const string DuplicationDataMessage = "Error! Data duplicated.";
        private const string SuccessfullyImportedCustomer = "Successfully imported customer - {0}";
        private const string SuccessfullyImportedBooking = "Successfully imported booking. TourPackage: {0}, Date: {1}";

        public static string ImportCustomers(TravelAgencyContext context, string xmlString)
        {
            var output = new StringBuilder();
            var xmlSerializer = new XmlSerializer(typeof(CustomerInputXmlModel[]), new XmlRootAttribute("Customers"));
            var stringReader = new StringReader(xmlString);

            var customers = (CustomerInputXmlModel[])xmlSerializer.Deserialize(stringReader);
            var validCustomers = new List<Customer>();

            foreach (var currentCustomer in customers)
            {
                if (!IsValid(currentCustomer))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                if (validCustomers.Any(x => x.FullName == currentCustomer.FullName ||
                    x.Email == currentCustomer.Email || x.PhoneNumber == currentCustomer.PhoneNumber))
                {
                    output.AppendLine(DuplicationDataMessage);
                    continue;
                }

                var customer = new Customer
                {
                    FullName = currentCustomer.FullName,
                    Email = currentCustomer.Email,
                    PhoneNumber = currentCustomer.PhoneNumber,
                };

                validCustomers.Add(customer);
                output.AppendLine(string.Format(SuccessfullyImportedCustomer, customer.FullName));
            }

            context.Customers.AddRange(validCustomers);
            context.SaveChanges();

            return output.ToString().TrimEnd();
        }

        public static string ImportBookings(TravelAgencyContext context, string jsonString)
        {
            var output = new StringBuilder();
            var bookings = JsonConvert.DeserializeObject<BookingInputJsonModel[]>(jsonString);
            var validBookings = new List<Booking>();

            foreach (var currentBooking in bookings)
            {
                bool isBookingDateValid = DateTime.TryParseExact(currentBooking.BookingDate, "yyyy-MM-dd", CultureInfo
                    .InvariantCulture, DateTimeStyles.None, out DateTime bookingDate);

                if (!isBookingDateValid)
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var customer = context.Customers.FirstOrDefault(x => x.FullName == currentBooking.CustomerName);
                var tourPackage = context.TourPackages.FirstOrDefault(x => x.PackageName == currentBooking.TourPackageName);

                if (customer == null || tourPackage == null)
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var booking = new Booking
                {
                    BookingDate = bookingDate,
                    CustomerId = customer.Id,
                    Customer = customer,
                    TourPackageId = tourPackage.Id,
                    TourPackage = tourPackage,
                };

                validBookings.Add(booking);
                output.AppendLine(string.Format(SuccessfullyImportedBooking,
                    booking.TourPackage.PackageName, booking.BookingDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)));
            }

            context.Bookings.AddRange(validBookings);
            context.SaveChanges();

            return output.ToString().TrimEnd();
        }

        public static bool IsValid(object dto)
        {
            var validateContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(dto, validateContext, validationResults, true);

            foreach (var validationResult in validationResults)
            {
                string currValidationMessage = validationResult.ErrorMessage;
            }

            return isValid;
        }
    }
}
