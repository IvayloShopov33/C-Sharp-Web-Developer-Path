using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Speed_Racing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            InitializeCars(cars);
            CommandsToDriveCars(cars);
            PrintCarsDetails(cars);
        }

        static void InitializeCars(List<Car> cars)
        {
            int carsCount = int.Parse(Console.ReadLine());
            for (int i = 1; i <= carsCount; i++)
            {
                string[] carDetails = Console.ReadLine().Split();
                string model = carDetails[0];
                double fuelAmount = double.Parse(carDetails[1]);
                double fuelConsumptionPerKilometer = double.Parse(carDetails[2]);
                double distanceTraveled = 0;
                Car car = new Car(model, fuelAmount, fuelConsumptionPerKilometer, distanceTraveled);
                cars.Add(car);
            }
        }
        static void CommandsToDriveCars(List<Car> cars)
        {
            string[] command = Console.ReadLine().Split();
            while (command[0] == "Drive")
            {
                string modelDriven = command[1];
                double kilometersDriven = double.Parse(command[2]);
                Car drivenCar = cars.First(g => g.Model == modelDriven);
                double neededFuel = drivenCar.FuelConsumptionPerKilometer * kilometersDriven;
                if (neededFuel <= drivenCar.FuelAmount)
                {
                    drivenCar.FuelAmount -= neededFuel;
                    drivenCar.DistanceTraveled += kilometersDriven;
                }
                else
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }
                command = Console.ReadLine().Split();
            }
        }
        static void PrintCarsDetails(List<Car> cars)
        {
            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.DistanceTraveled}");
            }
        }


    }

    public class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer, double distanceTraveled)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            this.DistanceTraveled = distanceTraveled;
        }
        public string Model { get; private set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double DistanceTraveled { get; set; }

    }
}
