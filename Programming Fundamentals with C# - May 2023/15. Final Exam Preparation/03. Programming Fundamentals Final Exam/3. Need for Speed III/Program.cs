using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Need_for_Speed_III
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            InitializeCars(cars);

            ReceiveCommands(cars);
            PrintCarsWithTheirDetails(cars);
        }

        static void InitializeCars(List<Car> cars)
        {
            int carsCount = int.Parse(Console.ReadLine());
            for (int i = 1; i <= carsCount; i++)
            {
                string[] carDetails = Console.ReadLine().Split('|');

                string model = carDetails[0];
                int mileage = int.Parse(carDetails[1]);
                int fuel = int.Parse(carDetails[2]);

                Car car = new Car(model, mileage, fuel);

                if (!cars.Contains(car))
                {
                    cars.Add(car);
                }
            }
        }

        static void ReceiveCommands(List<Car> cars)
        {
            string input;
            while ((input = Console.ReadLine()) != "Stop")
            {
                string[] commands = input.Split(" : ");
                string carModel = commands[1];

                if (cars.Any(x => x.Model == carModel))
                {
                    Car selectedCar = cars.First(g => g.Model == carModel);

                    if (commands[0] == "Drive")
                    {
                        int distance = int.Parse(commands[2]);
                        int fuel = int.Parse(commands[3]);

                        if (selectedCar.Fuel >= fuel)
                        {
                            selectedCar.Mileage += distance;
                            selectedCar.Fuel -= fuel;
                            Console.WriteLine($"{carModel} driven for {distance} kilometers. {fuel} liters of fuel consumed.");

                            if (selectedCar.Mileage >= 100000)
                            {
                                cars.Remove(selectedCar);
                                Console.WriteLine($"Time to sell the {carModel}!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Not enough fuel to make that ride");
                        }
                    }
                    else if (commands[0] == "Refuel")
                    {
                        int additionalFuel = int.Parse(commands[2]);
                        int refueledQuantity = selectedCar.Fuel + additionalFuel;

                        if (refueledQuantity > 75)
                        {
                            selectedCar.Fuel = 75;
                            refueledQuantity = refueledQuantity - selectedCar.Fuel - additionalFuel;
                            refueledQuantity = Math.Abs(refueledQuantity);
                        }
                        else
                        {
                            selectedCar.Fuel = refueledQuantity;
                            refueledQuantity = additionalFuel;
                        }

                        Console.WriteLine($"{carModel} refueled with {refueledQuantity} liters");
                    }
                    else if (commands[0] == "Revert")
                    {
                        int kilometers = int.Parse(commands[2]);
                        selectedCar.Mileage -= kilometers;

                        if (selectedCar.Mileage >= 10000)
                        {
                            Console.WriteLine($"{carModel} mileage decreased by {kilometers} kilometers");
                        }
                        else
                        {
                            selectedCar.Mileage = 10000;
                        }
                    }
                }
            }
        }

        static void PrintCarsWithTheirDetails(List<Car> cars)
        {
            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Model} -> Mileage: {car.Mileage} kms, Fuel in the tank: {car.Fuel} lt.");
            }
        }
    }

    public class Car
    {
        public Car(string model, int mileage, int fuel)
        {
            this.Model = model;
            this.Mileage = mileage;
            this.Fuel = fuel;
        }

        public string Model { get; private set; }

        public int Mileage { get; set; }

        public int Fuel { get; set; }
    }
}