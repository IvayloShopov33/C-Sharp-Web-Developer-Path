using VehiclesExtension.Core.Interfaces;
using VehiclesExtension.Models;

namespace VehiclesExtension.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            string[] carDetails = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Skip(1).ToArray();
            string[] truckDetails = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Skip(1).ToArray();
            string[] busDetails = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Skip(1).ToArray();

            Vehicle car = new Car(double.Parse(carDetails[0]), double.Parse(carDetails[1]), double.Parse(carDetails[2]));
            Vehicle truck = new Truck(double.Parse(truckDetails[0]), double.Parse(truckDetails[1]), double.Parse(truckDetails[2]));
            Bus bus = new Bus(double.Parse(busDetails[0]), double.Parse(busDetails[1]), double.Parse(busDetails[2]));

            int commandsCount = int.Parse(Console.ReadLine());
            for (int i = 1; i <= commandsCount; i++)
            {
                string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = commands[0];
                string vehicle = commands[1];
                double countOfKilometersOrLiters = double.Parse(commands[2]);

                if (command == "Drive")
                {
                    if (vehicle == "Car")
                    {
                        Console.WriteLine(car.Drive(countOfKilometersOrLiters));
                    }
                    else if (vehicle == "Truck")
                    {
                        Console.WriteLine(truck.Drive(countOfKilometersOrLiters));
                    }
                    else if (vehicle == "Bus")
                    {
                        Console.WriteLine(bus.Drive(countOfKilometersOrLiters));
                    }
                }
                else if (command == "DriveEmpty")
                {
                    Console.WriteLine(bus.DriveEmpty(countOfKilometersOrLiters));
                }
                else if (command == "Refuel")
                {
                    if (vehicle == "Car")
                    {
                        car.Refuel(countOfKilometersOrLiters);
                    }
                    else if (vehicle == "Truck")
                    {
                        truck.Refuel(countOfKilometersOrLiters);
                    }
                    else if (vehicle == "Bus")
                    {
                        bus.Refuel(countOfKilometersOrLiters);
                    }
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:F2}");
        }
    }
}
