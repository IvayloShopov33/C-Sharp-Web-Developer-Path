using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Car car = new SportCar(500, 100);
            car.Drive(8);
            Console.WriteLine(car.Fuel);

            Motorcycle motorcycle = new CrossMotorcycle(147, 50);
            Console.WriteLine(motorcycle.FuelConsumption);
        }
    }
}
