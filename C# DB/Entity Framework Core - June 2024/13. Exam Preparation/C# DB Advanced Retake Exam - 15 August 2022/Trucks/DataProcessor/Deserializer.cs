namespace Trucks.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Xml.Serialization;

    using Data;
    using Newtonsoft.Json;
    using Trucks.Data.Models;
    using Trucks.Data.Models.Enums;
    using Trucks.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedDespatcher
            = "Successfully imported despatcher - {0} with {1} trucks.";

        private const string SuccessfullyImportedClient
            = "Successfully imported client - {0} with {1} trucks.";

        public static string ImportDespatcher(TrucksContext context, string xmlString)
        {
            var output = new StringBuilder();
            var xmlSerializer = new XmlSerializer(typeof(DespatcherInputXmlModel[]), new XmlRootAttribute("Despatchers"));
            var stringReader = new StringReader(xmlString);
            var despatchers = (DespatcherInputXmlModel[])xmlSerializer.Deserialize(stringReader);
            var validDespatchers = new HashSet<Despatcher>();

            foreach (var currentDespatcher in despatchers)
            {
                if (!IsValid(currentDespatcher))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var despatcher = new Despatcher
                {
                    Name = currentDespatcher.Name,
                    Position = currentDespatcher.Position,
                };

                foreach (var currentTruck in currentDespatcher.Trucks)
                {
                    if (!IsValid(currentTruck))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    var truck = new Truck
                    {
                        RegistrationNumber = currentTruck.RegistrationNumber,
                        VinNumber = currentTruck.VinNumber,
                        TankCapacity = currentTruck.TankCapacity,
                        CargoCapacity = currentTruck.CargoCapacity,
                        CategoryType = (CategoryType)currentTruck.CategoryType,
                        MakeType = (MakeType)currentTruck.MakeType,
                    };

                    despatcher.Trucks.Add(truck);
                }

                validDespatchers.Add(despatcher);
                output.AppendLine(string.Format(SuccessfullyImportedDespatcher, despatcher.Name, despatcher.Trucks.Count));
            }

            context.Despatchers.AddRange(validDespatchers);
            context.SaveChanges();

            return output.ToString().TrimEnd();
        }
        public static string ImportClient(TrucksContext context, string jsonString)
        {
            var output = new StringBuilder();
            var clients = JsonConvert.DeserializeObject<ClientInputJsonModel[]>(jsonString);
            var validClients = new HashSet<Client>();

            foreach (var currentClient in clients)
            {
                if (!IsValid(currentClient) || currentClient.Type == "usual")
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var client = new Client
                {
                    Name = currentClient.Name,
                    Nationality = currentClient.Nationality,
                    Type = currentClient.Type,
                };

                foreach (var truckId in currentClient.Trucks.Distinct())
                {
                    if (!context.Trucks.Any(x => x.Id == truckId))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    client.ClientsTrucks.Add(new ClientTruck
                    {
                        TruckId = truckId,
                        Client = client,
                    });
                }

                validClients.Add(client);
                output.AppendLine(string.Format(SuccessfullyImportedClient, client.Name, client.ClientsTrucks.Count));
            }

            context.Clients.AddRange(validClients);
            context.SaveChanges();

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