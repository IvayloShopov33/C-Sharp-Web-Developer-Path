using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Raw_Data
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            ReceiveCars(cars);
            
            cars = FiltrateTheCars(cars);
            PrintValidCars(cars);
        }

        static void ReceiveCars(List<Car> cars)
        {
            int carsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < carsCount; i++)
            {
                string[] carDetails = Console.ReadLine().Split();
                string model = carDetails[0];
                int speed = int.Parse(carDetails[1]);
                int power = int.Parse(carDetails[2]);
                int weight = int.Parse(carDetails[3]);
                string type = carDetails[4];
                
                Car car = new Car(model, speed, power, weight, type);
                cars.Add(car);
            }
        }
        
        static List<Car> FiltrateTheCars(List<Car> cars)
        {
            string command = Console.ReadLine();
            if (command == "fragile")
            {
                cars = cars.Where(g => g.Cargo.Type == "fragile").Where(g => g.Cargo.Weight < 1000).ToList();
            }
            else if (command == "flamable")
            {
                cars = cars.Where(x => x.Cargo.Type == "flamable").Where(x => x.Engine.Power > 250).ToList();
            }

            return cars;
        }
        
        static void PrintValidCars(List<Car> cars)
        {
            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Model}");
            }
        }
    }

    public class Car
    {
        public Car(string model, int speed, int power, int weight, string type)
        {
            this.Model = model;
            this.Engine = new Engine(speed, power);
            this.Cargo = new Cargo(weight, type);
        }
        
        public string Model { get; private set; }
        
        public Engine Engine { get; private set; }
        
        public Cargo Cargo { get; private set; }
    }
    
    public class Engine
    {
        public Engine(int speed, int power)
        {
            this.Speed = speed;
            this.Power = power;
        }
        
        public int Speed { get; private set; }
        
        public int Power { get; private set; }
    }
    
    public class Cargo
    {
        public Cargo(int weight, string type)
        {
            this.Weight = weight;
            this.Type = type;
        }
        
        public int Weight { get; private set; }
        
        public string Type { get; private set; }
    }
}
