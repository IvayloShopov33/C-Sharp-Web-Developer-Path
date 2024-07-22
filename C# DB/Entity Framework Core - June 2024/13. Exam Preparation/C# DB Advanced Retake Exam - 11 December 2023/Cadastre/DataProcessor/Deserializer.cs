namespace Cadastre.DataProcessor
{
    using Cadastre.Data;
    using Cadastre.Data.Enumerations;
    using Cadastre.Data.Models;
    using Cadastre.DataProcessor.ImportDtos;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        private const string ErrorMessage =
            "Invalid Data!";
        private const string SuccessfullyImportedDistrict =
            "Successfully imported district - {0} with {1} properties.";
        private const string SuccessfullyImportedCitizen =
            "Succefully imported citizen - {0} {1} with {2} properties.";

        public static string ImportDistricts(CadastreContext dbContext, string xmlDocument)
        {
            var output = new StringBuilder();
            var xmlSerializer = new XmlSerializer(typeof(DistrictInputXmlModel[]),
                new XmlRootAttribute("Districts"));

            var stringReader = new StringReader(xmlDocument);
            var districts = (DistrictInputXmlModel[])xmlSerializer.Deserialize(stringReader);
            var validDistricts = new List<District>();

            foreach (var currentDistrict in districts)
            {
                if (!IsValid(currentDistrict))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                if (dbContext.Districts.Any(x => x.Name == currentDistrict.Name))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var district = new District
                {
                    Name = currentDistrict.Name,
                    PostalCode = currentDistrict.PostalCode,
                    Region = (Region)Enum.Parse(typeof(Region), currentDistrict.Region),
                };

                foreach (var currentProperty in currentDistrict.Properties)
                {
                    if (!IsValid(currentProperty))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime propertyDateOfAcquisition = DateTime
                        .ParseExact(currentProperty.DateOfAcquisition, "dd/MM/yyyy", CultureInfo
                        .InvariantCulture, DateTimeStyles.None);

                    if (dbContext.Properties.Any(x => x.PropertyIdentifier == currentProperty.PropertyIdentifier) ||
                        district.Properties.Any(x => x.PropertyIdentifier == currentProperty.PropertyIdentifier))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (dbContext.Properties.Any(x => x.Address == currentProperty.Address) ||
                        district.Properties.Any(x => x.Address == currentProperty.Address))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    var property = new Property
                    {
                        PropertyIdentifier = currentProperty.PropertyIdentifier,
                        Area = currentProperty.Area,
                        Details = currentProperty.Details,
                        Address = currentProperty.Address,
                        DateOfAcquisition = propertyDateOfAcquisition,
                    };

                    district.Properties.Add(property);
                }

                validDistricts.Add(district);
                output.AppendLine(string.Format(SuccessfullyImportedDistrict, district.Name, district.Properties.Count));
            }

            dbContext.Districts.AddRange(validDistricts);
            dbContext.SaveChanges();

            return output.ToString().TrimEnd();
        }

        public static string ImportCitizens(CadastreContext dbContext, string jsonDocument)
        {
            var output = new StringBuilder();
            var citizensDtos = JsonConvert.DeserializeObject<CitizenInputJsonModel[]>(jsonDocument);
            var validCitizens = new List<Citizen>();

            foreach (var currentCitizen in citizensDtos!)
            {
                if (!IsValid(currentCitizen))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime citizenBirthDate = DateTime
                    .ParseExact(currentCitizen.BirthDate, "dd-MM-yyyy", CultureInfo
                    .InvariantCulture, DateTimeStyles.None);

                var citizen = new Citizen
                {
                    FirstName = currentCitizen.FirstName,
                    LastName = currentCitizen.LastName,
                    BirthDate = citizenBirthDate,
                    MaritalStatus = (MaritalStatus)Enum.Parse(typeof(MaritalStatus), currentCitizen.MaritalStatus)
                };

                foreach (var propertyId in currentCitizen.Properties)
                {
                    citizen.PropertiesCitizens.Add(new PropertyCitizen
                    {
                        PropertyId = propertyId,
                        Citizen = citizen,
                    });
                }

                validCitizens.Add(citizen);
                output.AppendLine(string.Format(SuccessfullyImportedCitizen, citizen.FirstName, citizen.LastName, citizen.PropertiesCitizens.Count));
            }

            dbContext.Citizens.AddRange(validCitizens);
            dbContext.SaveChanges();

            return output.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
