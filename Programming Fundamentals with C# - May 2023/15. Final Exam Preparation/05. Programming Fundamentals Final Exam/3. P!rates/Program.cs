using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._P_rates
{
    class Program
    {
        static void Main(string[] args)
        {
            List<City> cities = new List<City>();
            InitializeCities(cities);

            ReceiveCommands(cities);
            PrintRemainedCities(cities);
        }

        static void InitializeCities(List<City> cities)
        {
            string[] targetedCities = Console.ReadLine().Split("||");
            while (targetedCities[0] != "Sail")
            {
                string cityName = targetedCities[0];
                int population = int.Parse(targetedCities[1]);
                int gold = int.Parse(targetedCities[2]);

                if (cities.Any(x => x.Name == cityName))
                {
                    City cityToUpdate = cities.First(x => x.Name == cityName);
                    cityToUpdate.Population += population;
                    cityToUpdate.Gold += gold;
                }
                else
                {
                    City city = new City(cityName, population, gold);
                    cities.Add(city);
                }

                targetedCities = Console.ReadLine().Split("||");
            }
        }

        static void ReceiveCommands(List<City> cities)
        {
            string[] commands = Console.ReadLine().Split("=>");
            while (commands[0] != "End")
            {
                string command = commands[0];
                string city = commands[1];
                City selectedCity = cities.First(g => g.Name == city);

                if (command == "Plunder")
                {
                    int people = int.Parse(commands[2]);
                    int goldQuantity = int.Parse(commands[3]);

                    selectedCity.Population -= people;
                    selectedCity.Gold -= goldQuantity;
                    Console.WriteLine($"{city} plundered! {goldQuantity} gold stolen, {people} citizens killed.");

                    if (selectedCity.Population == 0 || selectedCity.Gold == 0)
                    {
                        Console.WriteLine($"{city} has been wiped off the map!");
                        cities.Remove(selectedCity);
                    }
                }
                else if (command == "Prosper")
                {
                    int goldAmount = int.Parse(commands[2]);
                    if (goldAmount < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                    }
                    else
                    {
                        selectedCity.Gold += goldAmount;
                        Console.WriteLine($"{goldAmount} gold added to the city treasury. {city} now has {selectedCity.Gold} gold.");
                    }
                }

                commands = Console.ReadLine().Split("=>");
            }
        }

        static void PrintRemainedCities(List<City> cities)
        {
            if (cities.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");

                foreach (City city in cities)
                {
                    Console.WriteLine($"{city.Name} -> Population: {city.Population} citizens, Gold: {city.Gold} kg");
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }
    }

    public class City
    {
        public City(string name, int population, int gold)
        {
            this.Name = name;
            this.Population = population;
            this.Gold = gold;
        }

        public string Name { get; private set; }

        public int Population { get; set; }

        public int Gold { get; set; }
    }
}