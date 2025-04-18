using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Vehicle_Catalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            InitializeVehicles(vehicles);

            PrintTheCatalogue(vehicles);
            PrintAverageHorsepower(vehicles);
        }

        static void InitializeVehicles(List<Vehicle> vehicles)
        {
            string[] vehicleDetails = Console.ReadLine().Split();
            while (vehicleDetails[0] != "End")
            {
                string type = vehicleDetails[0];
                string model = vehicleDetails[1];
                string color = vehicleDetails[2];
                decimal horsepower = decimal.Parse(vehicleDetails[3]);

                Vehicle vehicle = new Vehicle(type, model, color, horsepower);
                vehicles.Add(vehicle);

                vehicleDetails = Console.ReadLine().Split();
            }
        }

        static void PrintTheCatalogue(List<Vehicle> vehicles)
        {
            string vehicleModel = Console.ReadLine();
            while (vehicleModel != "Close the Catalogue")
            {
                foreach (Vehicle vehicle in vehicles)
                {
                    if (vehicle.Model == vehicleModel)
                    {
                        if (vehicle.Type == "car")
                        {
                            Console.WriteLine($"Type: Car");
                        }
                        else
                        {
                            Console.WriteLine("Type: Truck");
                        }

                        Console.WriteLine($"Model: {vehicleModel}");
                        Console.WriteLine($"Color: {vehicle.Color}");
                        Console.WriteLine($"Horsepower: {vehicle.Horsepower}");

                        break;
                    }
                }

                vehicleModel = Console.ReadLine();
            }
        }

        static void PrintAverageHorsepower(List<Vehicle> vehicles)
        {
            decimal averageHP = vehicles
                .Where(vehicle => vehicle.Type == "car")
                .Select(vehicle => vehicle.Horsepower)
                .DefaultIfEmpty()
                .Average();

            Console.WriteLine($"Cars have average horsepower of: {averageHP:F2}.");
            averageHP = vehicles
                .Where(vehicle => vehicle.Type == "truck")
                .Select(vehicle => vehicle.Horsepower)
                .DefaultIfEmpty()
                .Average();

            Console.WriteLine($"Trucks have average horsepower of: {averageHP:F2}.");
        }
    }

    public class Vehicle
    {
        public Vehicle(string type, string model, string color, decimal horsepower)
        {
            this.Type = type;
            this.Model = model;
            this.Color = color;
            this.Horsepower = horsepower;
        }

        public string Type { get;  set; }

        public string Model { get;  set; }

        public string Color { get;  set; }

        public decimal Horsepower { get; set; }
    }
}