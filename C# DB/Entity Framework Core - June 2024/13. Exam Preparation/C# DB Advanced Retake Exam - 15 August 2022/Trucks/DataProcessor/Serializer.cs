namespace Trucks.DataProcessor
{
    using Newtonsoft.Json;
    using System.Xml.Serialization;

    using Data;
    using Trucks.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportDespatchersWithTheirTrucks(TrucksContext context)
        {
            var despatchersWithTheirTrucks = context.Despatchers
                .Where(x => x.Trucks.Any())
                .Select(x => new DespatcherOutputXmlModel
                {
                    Name = x.Name,
                    Trucks = x.Trucks
                        .Select(y => new TruckOutputXmlModel
                        {
                            RegistrationNumber = y.RegistrationNumber,
                            MakeType = y.MakeType.ToString(),
                        })
                        .OrderBy(y => y.RegistrationNumber)
                        .ToArray(),
                    TrucksCount = x.Trucks.Count,
                })
                .OrderByDescending(x => x.TrucksCount)
                .ThenBy(x => x.Name)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(DespatcherOutputXmlModel[]), new XmlRootAttribute("Despatchers"));
            var stringWriter = new StringWriter();
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);
            xmlSerializer.Serialize(stringWriter, despatchersWithTheirTrucks, namespaces);

            return stringWriter.ToString();
        }

        public static string ExportClientsWithMostTrucks(TrucksContext context, int capacity)
        {
            var clientsWithMostTrucks = context.Clients
                .Where(x => x.ClientsTrucks.Any(y => y.Truck.TankCapacity >= capacity))
                .Select(x => new ClientOutputJsonModel
                {
                    Name = x.Name,
                    Trucks = x.ClientsTrucks
                        .Where(y => y.Truck.TankCapacity >= capacity)
                        .OrderBy(y => y.Truck.MakeType)
                        .ThenByDescending(y => y.Truck.CargoCapacity)
                        .Select(y => new TruckOutputJsonModel
                        {
                            TruckRegistrationNumber = y.Truck.RegistrationNumber,
                            VinNumber = y.Truck.VinNumber,
                            TankCapacity = y.Truck.TankCapacity,
                            CargoCapacity = y.Truck.CargoCapacity,
                            CategoryType = y.Truck.CategoryType.ToString(),
                            MakeType = y.Truck.MakeType.ToString(),
                        })
                        .ToArray(),
                })
                .OrderByDescending(x => x.Trucks.Length)
                .ThenBy(x => x.Name)
                .Take(10)
                .ToArray();

            return JsonConvert.SerializeObject(clientsWithMostTrucks, Formatting.Indented);
        }
    }
}
