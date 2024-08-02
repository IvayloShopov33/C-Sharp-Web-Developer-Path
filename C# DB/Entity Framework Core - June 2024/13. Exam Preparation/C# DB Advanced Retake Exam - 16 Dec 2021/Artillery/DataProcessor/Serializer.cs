
namespace Artillery.DataProcessor
{
    using System.Xml.Serialization;
    using Newtonsoft.Json;
    
    using Data.Models.Enums;
    using Artillery.Data;
    using Artillery.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportShells(ArtilleryContext context, double shellWeight)
        {
            var shellsWithBiggerShellWeight = context.Shells
                .Where(x => x.ShellWeight > shellWeight)
                .Select(x => new ShellOutputJsonModel
                {
                    ShellWeight = x.ShellWeight,
                    Caliber = x.Caliber,
                    Guns = x.Guns
                        .Where(x => x.GunType == GunType.AntiAircraftGun)
                        .Select(y => new GunOutputJsonModel
                        {
                            GunType = y.GunType.ToString(),
                            GunWeight = y.GunWeight,
                            BarrelLength = y.BarrelLength,
                            Range = y.Range > 3000 ? "Long-range" : "Regular range",
                        })
                        .OrderByDescending(y => y.GunWeight)
                        .ToArray(),
                })
                .OrderBy(x => x.ShellWeight)
                .ToArray();

            return JsonConvert.SerializeObject(shellsWithBiggerShellWeight, Formatting.Indented);
        }

        public static string ExportGuns(ArtilleryContext context, string manufacturer)
        {
            var gunsByManufacturer = context.Guns
                .Where(x => x.Manufacturer.ManufacturerName == manufacturer)
                .OrderBy(x => x.BarrelLength)
                .Select(x => new GunOutputXmlModel
                {
                    Manufacturer = x.Manufacturer.ManufacturerName,
                    GunType = x.GunType.ToString(),
                    GunWeight = x.GunWeight.ToString(),
                    BarrelLength = x.BarrelLength.ToString(),
                    Range = x.Range.ToString(),
                    Countries = x.CountriesGuns
                        .Where(y => y.Country.ArmySize > 4_500_000)
                        .OrderBy(y => y.Country.ArmySize)
                        .Select(y => new CountryOutputXmlModel
                        {
                            CountryName = y.Country.CountryName,
                            ArmySize = y.Country.ArmySize.ToString(),
                        })
                        .ToArray(),
                })
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(GunOutputXmlModel[]), new XmlRootAttribute("Guns"));
            var stringWriter = new StringWriter();
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);
            xmlSerializer.Serialize(stringWriter, gunsByManufacturer, namespaces);

            return stringWriter.ToString();
        }
    }
}
