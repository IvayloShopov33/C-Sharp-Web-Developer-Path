using Cadastre.Data;
using Cadastre.DataProcessor.ExportDtos;
using Newtonsoft.Json;
using System.Globalization;
using System.Xml.Serialization;

namespace Cadastre.DataProcessor
{
    public class Serializer
    {
        public static string ExportPropertiesWithOwners(CadastreContext dbContext)
        {
            var propertiesWithOwners = dbContext.Properties
                 .Where(x => x.DateOfAcquisition >= DateTime.Parse("01/01/2000"))
                 .OrderByDescending(x => x.DateOfAcquisition)
                 .ThenBy(x => x.PropertyIdentifier)
                 .Select(x => new PropertyOutputJsonModel
                 {
                     PropertyIdentifier = x.PropertyIdentifier,
                     Area = x.Area,
                     Address = x.Address,
                     DateOfAcquisition = x.DateOfAcquisition.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                     Owners = x.PropertiesCitizens
                         .Where(y => y.PropertyId == x.Id)
                         .Select(y => new CitizenOutputJsonModel
                         {
                             LastName = y.Citizen.LastName,
                             MaritalStatus = y.Citizen.MaritalStatus.ToString(),
                         })
                         .OrderBy(y => y.LastName)
                         .ToList()
                 })
                 .ToList();

            return JsonConvert.SerializeObject(propertiesWithOwners, Formatting.Indented);
        }

        public static string ExportFilteredPropertiesWithDistrict(CadastreContext dbContext)
        {
            var filteredPropertiesWithDistrict = dbContext.Properties
                .Where(x => x.Area >= 100)
                .OrderByDescending(x => x.Area)
                .ThenBy(x => x.DateOfAcquisition)
                .Select(x => new PropertyOutputXmlModel
                {
                    PropertyIdentifier = x.PropertyIdentifier,
                    Area = x.Area,
                    DateOfAcquisition = x.DateOfAcquisition.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    PostalCode = x.District.PostalCode
                })
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(PropertyOutputXmlModel[]), new XmlRootAttribute("Properties"));
            var stringWriter = new StringWriter();
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");
            xmlSerializer.Serialize(stringWriter, filteredPropertiesWithDistrict, namespaces);

            return stringWriter.ToString();
        }
    }
}
