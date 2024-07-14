using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System.Text.Json;
//using System.Xml;

namespace JsonDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var car = new Car
            {
                Extras = new List<string> { "4x4", "Lights", "Trunk", "climate control" },
                ManufacturedOn = DateTime.UtcNow,
                Model = "Clio",
                Vendor = "Renault",
                Price = 2345.67m,
                Engine = new Engine { Volume = 1.9m, HorsePower = 108 }
            };

            // System.Text.Json
            var options = new JsonSerializerOptions { WriteIndented = true };
            //string json = JsonSerializer.Serialize(car, options);
            //File.WriteAllText("myCar.json", json);

            //var carObjectFromJson = JsonSerializer.Deserialize<Car>(json);
            //Console.WriteLine(carObjectFromJson.ToString());

            // Newtonsoft.Json
            var settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                },
                DateFormatString = "yyyy-MM-dd"
            };

            string carJson = JsonConvert.SerializeObject(car, settings);
            Console.WriteLine(carJson);

            var newCar = JsonConvert.DeserializeObject<Car>(carJson);
            Console.WriteLine(newCar.ToString());

            // LINQ-to-JSON
            var jObject = JObject.Parse(carJson);
            foreach (var child in jObject.Children())
            {
                Console.WriteLine(child);
                Console.WriteLine(new string('-', 55));
            }

            // XML-to-JSON
            string xml = @"<?xml version='1.0' standalone='no'?>
                <root>
                    <person id='1'>
                        <name>Alan</name>
                        <url>www.google.com</url>
                    </person>
                    <person id='2'>
                        <name>Louis</name>
                        <url>www.yahoo.com</url>
                    </person>
                </root>";

            //XmlDocument doc = new XmlDocument();
            //doc.LoadXml(xml);
            //string jsonText = JsonConvert.SerializeXmlNode(doc);
            //Console.WriteLine(jsonText);
        }
    }
}