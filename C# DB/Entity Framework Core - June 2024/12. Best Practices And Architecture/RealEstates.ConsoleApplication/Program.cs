using Microsoft.EntityFrameworkCore;
using RealEstates.Data;
using RealEstates.Services;
using System.Text;
using System.Xml.Serialization;
using RealEstates.Services.Models;
using System.Text.Json;
using RealEstates.Services.Contracts;

namespace RealEstates.ConsoleApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            var db = new ApplicationDbContext();
            db.Database.Migrate();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Property Search");
                Console.WriteLine("2. Most expensive districts");
                Console.WriteLine("3. Cheapest districts");
                Console.WriteLine("4. Average price per square meter");
                Console.WriteLine("5. Add tag");
                Console.WriteLine("6. Bulk tag to properties");
                Console.WriteLine("7. Properties after 2015, not on the first or the last floor - Full Info");
                Console.WriteLine("8. Properties after 2015, not on the first or the last floor - Full Info in XML format");
                Console.WriteLine("9. Properties after 2015, not on the first or the last floor - Full Info in JSON format");
                Console.WriteLine("0. Exit");

                bool isParsed = int.TryParse(Console.ReadLine(), out int option);

                if (isParsed && option == 0)
                {
                    break;
                }

                if (isParsed && (option >= 1 && option <= 9))
                {
                    switch (option)
                    {
                        case 1:
                            PropertySearch(db);
                            break;
                        case 2:
                            MostExpensiveDistricts(db);
                            break;
                        case 3:
                            CheapestDistricts(db);
                            break;
                        case 4:
                            AveragePricePerSquareMeter(db);
                            break;
                        case 5:
                            AddTag(db);
                            break;
                        case 6:
                            BulkTagToProperties(db);
                            break;
                        case 7:
                            PropertiesAfter2015OnMiddleFloors(db);
                            break;
                        case 8:
                            PropertiesAfter2015OnMiddleFloorsToXml(db);
                            break;
                        case 9:
                            PropertiesAfter2015OnMiddleFloorsToJson(db);
                            break;

                    }

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        private static void PropertySearch(ApplicationDbContext dbContext)
        {
            Console.Write("Min price:");
            int minPrice = int.Parse(Console.ReadLine());
            Console.Write("Max price:");
            int maxPrice = int.Parse(Console.ReadLine());
            Console.Write("Min size:");
            int minSize = int.Parse(Console.ReadLine());
            Console.Write("Max size:");
            int maxSize = int.Parse(Console.ReadLine());

            IPropertiesService service = new PropertiesService(dbContext);
            var properties = service.Search(minPrice, maxPrice, minSize, maxSize);

            foreach (var property in properties)
            {
                Console.WriteLine($"{property.DistrictName}; {property.BuildingType}; {property.PropertyType}; {property.Size}m2; {property.Price:f2}$");
            }
        }

        private static void MostExpensiveDistricts(ApplicationDbContext dbContext)
        {
            Console.Write("Districts Count:");
            int districtsCount = int.Parse(Console.ReadLine());

            IDistrictsService districtsService = new DistrictsService(dbContext);
            var districts = districtsService.GetMostExpensiveDistricts(districtsCount);

            foreach (var district in districts)
            {
                Console.WriteLine($"{district.Name} => {district.AveragePricePerSquareMeter:f2}$/m2, {district.PropertiesCount}");
            }
        }

        private static void CheapestDistricts(ApplicationDbContext dbContext)
        {
            Console.Write("Districts Count:");
            int districtsCount = int.Parse(Console.ReadLine());

            IDistrictsService districtsService = new DistrictsService(dbContext);
            var districts = districtsService.GetCheapestDistricts(districtsCount);

            foreach (var district in districts)
            {
                Console.WriteLine($"{district.Name} => {district.AveragePricePerSquareMeter:f2}$/m2, {district.PropertiesCount}");
            }
        }

        private static void AveragePricePerSquareMeter(ApplicationDbContext dbContext)
        {
            IPropertiesService propertiesService = new PropertiesService(dbContext);
            Console.WriteLine($"Average price per square meter is {propertiesService.AveragePricePerSquareMeter():f2}$");
        }

        private static void AddTag(ApplicationDbContext dbContext)
        {
            Console.Write("Tag's name:");
            string tagName = Console.ReadLine();
            Console.Write("Tag's importance (optional):");
            bool isImportanceSetOrNot = int.TryParse(Console.ReadLine(), out int tagImportance);
            int? importance = isImportanceSetOrNot ? tagImportance : null;

            IPropertiesService propertiesService = new PropertiesService(dbContext);
            ITagService tagService = new TagService(dbContext, propertiesService);
            tagService.Add(tagName, tagImportance);
        }

        private static void BulkTagToProperties(ApplicationDbContext dbContext)
        {
            Console.WriteLine("Bulk operation started...");
            IPropertiesService propertiesService = new PropertiesService(dbContext);
            ITagService tagService = new TagService(dbContext, propertiesService);
            tagService.BulkTagToProperties();
            Console.WriteLine("Bulk operation finished.");
        }

        private static void PropertiesAfter2015OnMiddleFloors(ApplicationDbContext dbContext)
        {
            Console.Write("Count of properties: ");
            int count = int.Parse(Console.ReadLine());
            IPropertiesService propertiesService = new PropertiesService(dbContext);
            var properties = propertiesService.GetFullData(count);

            foreach (var property in properties)
            {
                Console.WriteLine($"{property.DistrictName}; {property.BuildingType}; {property.PropertyType}; Year: {property.Year}; Floor: {property.Floor}; {property.Size}m2; {property.Price:f2}$; Id = {property.Id}");
                Console.WriteLine($"Tags: {string.Join(", ", property.Tags.Select(x => x.Name))}");
                Console.WriteLine();
            }
        }

        private static void PropertiesAfter2015OnMiddleFloorsToXml(ApplicationDbContext dbContext)
        {
            Console.Write("Count of properties: ");
            int count = int.Parse(Console.ReadLine());
            IPropertiesService propertiesService = new PropertiesService(dbContext);
            var properties = propertiesService.GetFullData(count);
            var xmlSerializer = new XmlSerializer(typeof(PropertyInfoFullDataDto[]));
            var stringWriter = new StringWriter();
            xmlSerializer.Serialize(stringWriter, properties);
            Console.WriteLine(stringWriter.ToString().TrimEnd());
        }

        private static void PropertiesAfter2015OnMiddleFloorsToJson(ApplicationDbContext dbContext)
        {
            Console.Write("Count of properties: ");
            int count = int.Parse(Console.ReadLine());
            IPropertiesService propertiesService = new PropertiesService(dbContext);
            var properties = propertiesService.GetFullData(count);

            var jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            Console.WriteLine(JsonSerializer.Serialize(properties, jsonOptions));
        }
    }
}