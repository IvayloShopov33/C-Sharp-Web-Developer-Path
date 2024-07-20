using RealEstates.Data;
using RealEstates.Services;
using RealEstates.Services.Contracts;
using System.Text.Json;

namespace RealEstates.Importer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ImportJsonFile("imot.bg-houses-Sofia-raw-data-2021-03-18.json");
            Console.WriteLine();
            ImportJsonFile("imot.bg-raw-data-2021-03-18.json");
        }

        public static void ImportJsonFile(string fileName)
        {
            var dbContext = new ApplicationDbContext();
            IPropertiesService propertiesService = new PropertiesService(dbContext);
            var properties =
                JsonSerializer.Deserialize<IEnumerable<PropertyAsJson>>(File.ReadAllText(fileName));

            foreach (var property in properties)
            {
                propertiesService.Add(property.District, property.Floor, property.TotalFloors,
                    property.Size, property.YardSize, property.Year,
                    property.Type, property.BuildingType, property.Price);
            }
        }
    }
}
