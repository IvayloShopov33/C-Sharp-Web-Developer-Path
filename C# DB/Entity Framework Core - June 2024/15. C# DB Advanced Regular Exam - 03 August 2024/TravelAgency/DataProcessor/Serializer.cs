using Newtonsoft.Json;
using System.Globalization;
using System.Xml.Serialization;

using TravelAgency.Data;
using TravelAgency.Data.Models.Enums;
using TravelAgency.DataProcessor.ExportDtos;

namespace TravelAgency.DataProcessor
{
    public class Serializer
    {
        public static string ExportGuidesWithSpanishLanguageWithAllTheirTourPackages(TravelAgencyContext context)
        {
            var guidesWithSpanishLanguageWithAllTheirTourPackages = context.Guides
                .Where(x => x.Language == Language.Spanish)
                .Select(x => new GuideOutputXmlModel
                {
                    FullName = x.FullName,
                    TourPackages = x.TourPackagesGuides
                        .OrderByDescending(y => y.TourPackage.Price)
                        .ThenBy(y => y.TourPackage.PackageName)
                        .Select(y => new TourPackageOutputXmlModel
                        {
                            Name = y.TourPackage.PackageName,
                            Description = y.TourPackage.Description,
                            Price = $"{y.TourPackage.Price:f2}",
                        })
                        .ToArray(),
                })
                .OrderByDescending(x => x.TourPackages.Length)
                .ThenBy(x => x.FullName)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(GuideOutputXmlModel[]), new XmlRootAttribute("Guides"));
            var stringWriter = new StringWriter();
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);
            xmlSerializer.Serialize(stringWriter, guidesWithSpanishLanguageWithAllTheirTourPackages, namespaces);

            return stringWriter.ToString();
        }

        public static string ExportCustomersThatHaveBookedHorseRidingTourPackage(TravelAgencyContext context)
        {
            var customersThatHaveBookedHorseRidingTourPackage = context.Customers
                .Where(x => x.Bookings.Any(x => x.TourPackage.PackageName == "Horse Riding Tour"))
                .Select(x => new CustomerOutputJsonModel
                {
                    FullName = x.FullName,
                    PhoneNumber = x.PhoneNumber,
                    Bookings = x.Bookings
                        .Where(y => y.TourPackage.PackageName == "Horse Riding Tour")
                        .OrderBy(y => y.BookingDate)
                        .Select(y => new BookingOutputJsonModel
                        {
                            TourPackageName = y.TourPackage.PackageName,
                            Date = y.BookingDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                        })
                        .ToArray(),
                })
                .OrderByDescending(x => x.Bookings.Length)
                .ThenBy(x => x.FullName)
                .ToArray();

            return JsonConvert.SerializeObject(customersThatHaveBookedHorseRidingTourPackage, Formatting.Indented);
        }
    }
}