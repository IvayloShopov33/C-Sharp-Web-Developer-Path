using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using CarDealer.XML_Helper;
using Microsoft.EntityFrameworkCore;
using System.Xml.Serialization;

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
            string suppliersXml = File.ReadAllText("../../../Datasets/suppliers.xml");
            Console.WriteLine(ImportSuppliers(carDealerDbContext, suppliersXml));

            // Task 10 - Import Parts
            string partsXml = File.ReadAllText("../../../Datasets/parts.xml");
            Console.WriteLine(ImportParts(carDealerDbContext, partsXml));

            // Task 11 - Import Cars
            string carsXml = File.ReadAllText("../../../Datasets/cars.xml");
            Console.WriteLine(ImportCars(carDealerDbContext, carsXml));

            // Task 12 - Import Customers
            string customersXml = File.ReadAllText("../../../Datasets/customers.xml");
            Console.WriteLine(ImportCustomers(carDealerDbContext, customersXml));

            // Task 13 - Import Sales
            string salesXml = File.ReadAllText("../../../Datasets/sales.xml");
            Console.WriteLine(ImportSales(carDealerDbContext, salesXml));

            // Task 14 - Export Cars With Distance
            Console.WriteLine(GetCarsWithDistance(carDealerDbContext));

            // Task 15 - Export Cars From Make BMW
            Console.WriteLine(GetCarsFromMakeBmw(carDealerDbContext));

            // Task 16 - Export Local Suppliers
            Console.WriteLine(GetLocalSuppliers(carDealerDbContext));

            // Task 17 - Export Cars With Their List Of Parts
            Console.WriteLine(GetCarsWithTheirListOfParts(carDealerDbContext));

            // Task 18 - Export Total Sales By Customer
            Console.WriteLine(GetTotalSalesByCustomer(carDealerDbContext));

            // Task 19 - Export Sales with Applied Discount
            Console.WriteLine(GetSalesWithAppliedDiscount(carDealerDbContext));
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(SupplierInputModel[]), new XmlRootAttribute("Suppliers"));
            var textRead = new StringReader(inputXml);
            var dtoSuppliers = (SupplierInputModel[])serializer.Deserialize(textRead);
            var suppliers = mapper.Map<Supplier[]>(dtoSuppliers);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {context.Suppliers.Count()}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(PartInputModel[]), new XmlRootAttribute("Parts"));
            var textRead = new StringReader(inputXml);
            var dtoParts = (PartInputModel[])serializer.Deserialize(textRead);
            var supplierIds = context.Suppliers
                .Select(x => x.Id)
                .ToArray();

            var parts = dtoParts
                .Where(x => supplierIds.Contains(x.SupplierId))
                .Select(x => new Part
                {
                    Name = x.Name,
                    Price = x.Price,
                    Quantity = x.Quantity,
                    SupplierId = x.SupplierId
                })
                .ToArray();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {context.Parts.Count()}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(CarInputModel[]), new XmlRootAttribute("Cars"));
            var textRead = new StringReader(inputXml);
            var dtoCars = (CarInputModel[])serializer.Deserialize(textRead);
            var cars = new List<Car>();
            var carPartIds = context.PartsCars
                .Select(x => x.PartId)
                .ToArray();

            foreach (var currentCar in dtoCars)
            {
                var distinctedPartIds = currentCar.Parts.Select(x => x.Id).Distinct();

                var car = new Car
                {
                    Make = currentCar.Make,
                    Model = currentCar.Model,
                    TraveledDistance = currentCar.TraveledDistance,
                };

                foreach (var partId in distinctedPartIds)
                {
                    var partCar = new PartCar
                    {
                        PartId = partId
                    };

                    car.PartsCars.Add(partCar);
                }

                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {context.Cars.Count()}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(CustomerInputModel[]), new XmlRootAttribute("Customers"));
            var textRead = new StringReader(inputXml);
            var dtoCustomers = (CustomerInputModel[])serializer.Deserialize(textRead);
            var customers = mapper.Map<Customer[]>(dtoCustomers);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {context.Customers.Count()}";
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(SaleInputModel[]), new XmlRootAttribute("Sales"));
            var textRead = new StringReader(inputXml);
            var dtoSales = (SaleInputModel[])serializer.Deserialize(textRead);
            var sales = mapper.Map<Sale[]>(dtoSales);

            var carIds = context.Cars
                .Select(x => x.Id)
                .ToArray();

            sales = sales
                .Where(x => carIds.Contains(x.CarId))
                .ToArray();

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {context.Sales.Count()}";
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var carsWithDistance = context.Cars
                .Select(x => new CarsWithDistanceOutputModel
                {
                    Make = x.Make,
                    Model = x.Model,
                    TraveledDistance = x.TraveledDistance
                })
                .Where(x => x.TraveledDistance > 2000000)
                .OrderBy(x => x.Make)
                .ThenBy(x => x.Model)
                .Take(10)
                .ToList();

            return XmlConverter.Serialize(carsWithDistance, "cars");
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var carsFromMakeBmw = context.Cars
                .Where(x => x.Make == "BMW")
                .Select(x => new BMWCarsOutputModel
                {
                    Id = x.Id,
                    Model = x.Model,
                    TraveledDistance = x.TraveledDistance
                })
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TraveledDistance)
                .ToList();

            return XmlConverter.Serialize(carsFromMakeBmw, "cars");
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var localSuppliers = context.Suppliers
                .Where(x => !x.IsImporter)
                .Select(x => new SupplierOutputModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    PartsCount = x.Parts.Count
                })
                .ToList();

            return XmlConverter.Serialize(localSuppliers, "suppliers");
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carsWithTheirListOfParts = context.Cars
                .Select(x => new CarsOutputAttributesModel
                {
                    Make = x.Make,
                    Model = x.Model,
                    TraveledDistance = x.TraveledDistance,
                    CarParts = x.PartsCars.Select(y => new CarPartsOutputModel
                    {
                        Name = y.Part.Name,
                        Price = y.Part.Price
                    })
                    .OrderByDescending(x => x.Price)
                    .ToList()
                })
                .OrderByDescending(x => x.TraveledDistance)
                .ThenBy(x => x.Model)
                .Take(5)
                .ToList();

            return XmlConverter.Serialize(carsWithTheirListOfParts, "cars");
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var totalSalesByCustomer = context.Customers
                .AsEnumerable()
                .Where(x => x.Sales.Any())
                .Select(x => new CustomerOutputModel
                {
                    FullName = x.Name,
                    CarsBought = x.Sales.Count,
                    SpentMoney = (decimal)CalculateSpentMoneyOnCars(x.Sales, x.IsYoungDriver, 5)
                })
                .OrderByDescending(x => x.SpentMoney)
                .ToList();

            return XmlConverter.Serialize(totalSalesByCustomer, "customers");
        }

        private static double CalculateSpentMoneyOnCars(ICollection<Sale> sales, bool isYoungDriver, decimal discount)
        {
            if (isYoungDriver)
            {
                return sales.Sum(y => y.Car.PartsCars.Sum(pc => Math.Round((double)pc.Part.Price * 0.95, 2)));
            }

            return sales.Sum(y => y.Car.PartsCars.Sum(pc => (double)pc.Part.Price));
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var salesWithAppliedDiscount = context.Sales
                .Select(x => new SalesWithAppliedDiscountOutputModel
                {
                    Car = new CarsWithDistanceAttributesOutputModel
                    {
                        Make = x.Car.Make,
                        Model = x.Car.Model,
                        TraveledDistance = x.Car.TraveledDistance,
                    },
                    Discount = (int)x.Discount,
                    CustomerName = x.Customer.Name,
                    Price = x.Car.PartsCars.Sum(y => y.Part.Price),
                    PriceWithDiscount = Math.Round((double)x.Car.PartsCars.Sum(y => y.Part.Price) - (double)x.Car.PartsCars.Sum(y => y.Part.Price) * ((double)x.Discount / 100), 4),
                })
                .ToList();

            return XmlConverter.Serialize(salesWithAppliedDiscount, "sales");
        }
    }
}