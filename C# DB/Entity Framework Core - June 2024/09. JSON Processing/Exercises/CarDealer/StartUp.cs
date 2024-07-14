using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Globalization;

namespace CarDealer
{
    public class StartUp
    {
        static IMapper mapper;

        public static void Main()
        {
            var carDealerDbContext = new CarDealerContext();
            carDealerDbContext.Database.Migrate();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });

            mapper = config.CreateMapper();

            // Task 9 - Import Suppliers
            string suppliersJson = File.ReadAllText("../../../Datasets/suppliers.json");
            Console.WriteLine(ImportSuppliers(carDealerDbContext, suppliersJson));

            // Task 10 - Import Parts
            string partsJson = File.ReadAllText("../../../Datasets/parts.json");
            Console.WriteLine(ImportParts(carDealerDbContext, partsJson));

            // Task 11 - Import Cars
            string carsJson = File.ReadAllText("../../../Datasets/cars.json");
            Console.WriteLine(ImportCars(carDealerDbContext, carsJson));

            // Task 12 - Import Customers
            string customersJson = File.ReadAllText("../../../Datasets/customers.json");
            Console.WriteLine(ImportCustomers(carDealerDbContext, customersJson));

            // Task 13 - Import Sales
            string salesJson = File.ReadAllText("../../../Datasets/sales.json");
            Console.WriteLine(ImportSales(carDealerDbContext, salesJson));

            // Task 14 - Export Ordered Customers
            Console.WriteLine(GetOrderedCustomers(carDealerDbContext));

            // Task 15 - Export Cars From Make Toyota
            Console.WriteLine(GetCarsFromMakeToyota(carDealerDbContext));

            // Task 16 - Export Local Suppliers
            Console.WriteLine(GetLocalSuppliers(carDealerDbContext));

            // Task 17 - Export Cars With Their List Of Parts
            Console.WriteLine(GetCarsWithTheirListOfParts(carDealerDbContext));

            // Task 18 - Export Total Sales By Customer
            Console.WriteLine(GetTotalSalesByCustomer(carDealerDbContext));

            // Task 19 - Export Sales With Applied Discount
            Console.WriteLine(GetSalesWithAppliedDiscount(carDealerDbContext));
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var dtoSuppliers = JsonConvert.DeserializeObject<IEnumerable<ImportSupplierInputModel>>(inputJson);
            var suppliers = mapper.Map<IEnumerable<Supplier>>(dtoSuppliers);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {context.Suppliers.Count()}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var dtoParts = JsonConvert.DeserializeObject<IEnumerable<ImportPartInputModel>>(inputJson)
                .Where(x => x.SupplierId <= context.Suppliers.Count());
            var parts = mapper.Map<IEnumerable<Part>>(dtoParts);

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {context.Parts.Count()}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var dtoCars = JsonConvert.DeserializeObject<IEnumerable<ImportCarInputModel>>(inputJson);
            var cars = new List<Car>();

            foreach (var currentCar in dtoCars)
            {
                var car = new Car
                {
                    Make = currentCar.Make,
                    Model = currentCar.Model,
                    TraveledDistance = currentCar.TraveledDistance,
                };

                foreach (var partId in currentCar.PartsId.Distinct())
                {
                    car.PartsCars.Add(new PartCar
                    {
                        PartId = partId,
                    });
                }

                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {context.Cars.Count()}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var dtoCustomers = JsonConvert.DeserializeObject<IEnumerable<ImportCustomerInputModel>>(inputJson);
            var customers = mapper.Map<IEnumerable<Customer>>(dtoCustomers);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {context.Customers.Count()}.";
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var dtoSales = JsonConvert.DeserializeObject<IEnumerable<ImportSaleInputModel>>(inputJson);
            var sales = mapper.Map<IEnumerable<Sale>>(dtoSales);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {context.Sales.Count()}.";
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(x => x.BirthDate)
                .ThenBy(x => x.IsYoungDriver)
                .Select(x => new { x.Name, BirthDate = x.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture), x.IsYoungDriver })
                .ToList();

            return JsonConvert.SerializeObject(customers, Formatting.Indented);
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var carsFromMakeToyota = context.Cars
                .Select(x => new { x.Id, x.Make, x.Model, x.TraveledDistance })
                .Where(x => x.Make == "Toyota")
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TraveledDistance)
                .ToList();

            return JsonConvert.SerializeObject(carsFromMakeToyota, Formatting.Indented);
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(x => !x.IsImporter)
                .Select(x => new { x.Id, x.Name, PartsCount = x.Parts.Count })
                .ToList();

            return JsonConvert.SerializeObject(suppliers, Formatting.Indented);
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carsWithTheirListOfParts = context.Cars
                .Select(x => new
                {
                    car = new { x.Make, x.Model, x.TraveledDistance },
                    parts = x.PartsCars.Select(y => new { y.Part.Name, Price = $"{y.Part.Price:f2}" })
                })
                .ToList();

            return JsonConvert.SerializeObject(carsWithTheirListOfParts, Formatting.Indented);
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customersWithTheirMoneySpentOnCars = context.Customers
                .Include(c => c.Sales)
                .ThenInclude(s => s.Car)
                .ThenInclude(c => c.PartsCars)
                .ThenInclude(pc => pc.Part)
                .Where(x => x.Sales.Any(s => s.CarId != null))
                .Select(x => new
                {
                    FullName = x.Name,
                    BoughtCars = x.Sales.Count(s => s.CarId != null),
                    SpentMoney = x.Sales.Sum(s => s.Car.PartsCars.Sum(pc => pc.Part.Price))
                })
                .OrderByDescending(x => x.SpentMoney)
                .ThenByDescending(x => x.BoughtCars)
                .ToArray();

            var jsonSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
            };

            return JsonConvert.SerializeObject(customersWithTheirMoneySpentOnCars, jsonSettings);
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var salesWithAppliedDiscount = context.Sales
                .Take(10)
                .Select(x => new
                {
                    car = new { x.Car.Make, x.Car.Model, x.Car.TraveledDistance },
                    customerName = x.Customer.Name,
                    discount = $"{x.Discount:f2}",
                    price = $"{x.Car.PartsCars.Sum(y => y.Part.Price):f2}",
                    priceWithDiscount = $"{x.Car.PartsCars.Sum(y => y.Part.Price) - (x.Car.PartsCars.Sum(y => y.Part.Price) * (x.Discount / 100)):f2}"
                })
                .ToList();

            return JsonConvert.SerializeObject(salesWithAppliedDiscount, Formatting.Indented);
        }
    }
}