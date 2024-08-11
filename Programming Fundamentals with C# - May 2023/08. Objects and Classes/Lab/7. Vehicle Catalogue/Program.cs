using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._Vehicle_Catalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split('/');
            Catalog catalog = new Catalog();

            while (input[0] != "end")
            {
                string typeOfVehicle = input[0];
                string brand = input[1];
                string model = input[2];
                if (typeOfVehicle == "Car")
                {
                    string horsePower = input[3];
                    Car car = new Car();
                    car.Brand = brand;
                    car.Model = model;
                    car.HorsePower = horsePower;
                   catalog.Cars.Add(car);
                }
                else if (typeOfVehicle == "Truck")
                {
                    string weight = input[3];
                    Truck truck = new Truck();
                    truck.Brand = brand;
                    truck.Model = model;
                    truck.Weight = weight;
                    catalog.Trucks.Add(truck);
                }

                input = Console.ReadLine().Split('/');
            }

            if (catalog.Cars.Count > 0)
            {
                Console.WriteLine("Cars:");
                foreach (var car in catalog.Cars.OrderBy(x => x.Brand))
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }
            }
            if (catalog.Trucks.Count > 0)
            {
                Console.WriteLine("Trucks:");
                foreach (var truck in catalog.Trucks.OrderBy(x => x.Brand))
                {
                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                }
            }
        }
    }

    class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Weight { get; set; }

    }

    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string HorsePower { get; set; }
    }

    class Catalog
    {
        public Catalog()
        {
            Trucks = new List<Truck>();
            Cars = new List<Car>();
        }
        public List<Truck> Trucks { get; set; }
        public List<Car> Cars { get; set; }
    }
}
