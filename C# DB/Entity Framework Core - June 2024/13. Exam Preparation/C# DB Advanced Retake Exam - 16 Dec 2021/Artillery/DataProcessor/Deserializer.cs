namespace Artillery.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Xml.Serialization;
    using Newtonsoft.Json;

    using Artillery.Data;
    using Artillery.Data.Models;
    using Artillery.Data.Models.Enums;
    using Artillery.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage =
            "Invalid data.";
        private const string SuccessfulImportCountry =
            "Successfully import {0} with {1} army personnel.";
        private const string SuccessfulImportManufacturer =
            "Successfully import manufacturer {0} founded in {1}.";
        private const string SuccessfulImportShell =
            "Successfully import shell caliber #{0} weight {1} kg.";
        private const string SuccessfulImportGun =
            "Successfully import gun {0} with a total weight of {1} kg. and barrel length of {2} m.";

        public static string ImportCountries(ArtilleryContext context, string xmlString)
        {
            var output = new StringBuilder();
            var xmlSerializer = new XmlSerializer(typeof(CountryInputXmlModel[]), new XmlRootAttribute("Countries"));
            var stringReader = new StringReader(xmlString);

            var countries = (CountryInputXmlModel[])xmlSerializer.Deserialize(stringReader);
            var validCountries = new List<Country>();

            foreach (var country in countries)
            {
                if (!IsValid(country))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                validCountries.Add(new Country
                {
                    CountryName = country.CountryName,
                    ArmySize = country.ArmySize,
                });

                output.AppendLine(string.Format(SuccessfulImportCountry, country.CountryName, country.ArmySize));
            }

            context.Countries.AddRange(validCountries);
            context.SaveChanges();

            return output.ToString().TrimEnd();
        }

        public static string ImportManufacturers(ArtilleryContext context, string xmlString)
        {
            var output = new StringBuilder();
            var xmlSerializer = new XmlSerializer(typeof(ManufacturerInputXmlModel[]), new XmlRootAttribute("Manufacturers"));
            var stringReader = new StringReader(xmlString);

            var manufacturers = (ManufacturerInputXmlModel[])xmlSerializer.Deserialize(stringReader);
            var validManufacturers = new List<Manufacturer>();

            foreach (var manufacturer in manufacturers)
            {
                if (!IsValid(manufacturer) || validManufacturers.Any(x => x.ManufacturerName == manufacturer.ManufacturerName))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                validManufacturers.Add(new Manufacturer
                {
                    ManufacturerName = manufacturer.ManufacturerName,
                    Founded = manufacturer.Founded,
                });

                var foundedDetails = manufacturer.Founded.Split(", ").ToArray();
                var manufacturerTownFounded = foundedDetails[foundedDetails.Length - 2];
                var manufacturerCountryFounded = foundedDetails.Last();

                output.AppendLine(string.Format(SuccessfulImportManufacturer, manufacturer.ManufacturerName, $"{manufacturerTownFounded}, {manufacturerCountryFounded}"));
            }

            context.Manufacturers.AddRange(validManufacturers);
            context.SaveChanges();

            return output.ToString().TrimEnd();
        }

        public static string ImportShells(ArtilleryContext context, string xmlString)
        {
            var output = new StringBuilder();
            var xmlSerializer = new XmlSerializer(typeof(ShellInputXmlModel[]), new XmlRootAttribute("Shells"));
            var stringReader = new StringReader(xmlString);

            var shells = (ShellInputXmlModel[])xmlSerializer.Deserialize(stringReader);
            var validShells = new List<Shell>();

            foreach (var shell in shells)
            {
                if (!IsValid(shell))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                validShells.Add(new Shell
                {
                    ShellWeight = shell.ShellWeight,
                    Caliber = shell.Caliber,
                });

                output.AppendLine(string.Format(SuccessfulImportShell, shell.Caliber, shell.ShellWeight));
            }

            context.Shells.AddRange(validShells);
            context.SaveChanges();

            return output.ToString().TrimEnd();
        }

        public static string ImportGuns(ArtilleryContext context, string jsonString)
        {
            var output = new StringBuilder();
            var guns = JsonConvert.DeserializeObject<GunInputJsonModel[]>(jsonString);
            var validGuns = new List<Gun>();

            foreach (var currentGun in guns)
            {
                bool isGunTypeValid = Enum.TryParse(currentGun.GunType, out GunType gunType);

                if (!IsValid(currentGun) || !isGunTypeValid)
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var gun = new Gun
                {
                    ManufacturerId = currentGun.ManufacturerId,
                    GunWeight = currentGun.GunWeight,
                    BarrelLength = currentGun.BarrelLength,
                    NumberBuild = currentGun.NumberBuild,
                    Range = currentGun.Range,
                    GunType = gunType,
                    ShellId = currentGun.ShellId,
                };

                foreach (var country in currentGun.Countries)
                {
                    gun.CountriesGuns.Add(new CountryGun
                    {
                        CountryId = country.Id,
                        Gun = gun,
                    });
                }

                validGuns.Add(gun);
                output.AppendLine(string.Format(SuccessfulImportGun, gun.GunType, gun.GunWeight, gun.BarrelLength));
            }

            context.Guns.AddRange(validGuns);
            context.SaveChanges();

            return output.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}