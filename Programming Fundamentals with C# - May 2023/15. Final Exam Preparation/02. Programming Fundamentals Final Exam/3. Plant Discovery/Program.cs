using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Plant_Discovery
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Plant> plants = new List<Plant>();
            InitializePlantsAndTheirDetails(plants);
            UpgradePlantsDetails(plants);
            PrintPlantsDetails(plants);
        }

        static void InitializePlantsAndTheirDetails(List<Plant> plants)
        {
            int plantsCount = int.Parse(Console.ReadLine());
            for (int i = 1; i <= plantsCount; i++)
            {
                string[] plantDetails = Console.ReadLine().Split("<->");
                string plantName = plantDetails[0];
                int rarity = int.Parse(plantDetails[1]);
                List<int> rating = new List<int>();
                Plant plant = new Plant(plantName, rarity, rating);
                if (plants.Any(x => x.PlantName == plantName))
                {
                    Plant plantToUprageRarity = plants.First(g => g.PlantName == plantName);
                    plantToUprageRarity.PlantRarity = rarity;
                }
                else
                {
                    plants.Add(plant);
                }
            }
        }

        static void UpgradePlantsDetails(List<Plant> plants)
        {
            string[] commands = Console.ReadLine().Split(": ");
            while (commands[0] != "Exhibition")
            {
                string[] commandDetails = commands[1].Split(" - ");
                string givenPlantName = commandDetails[0];
                bool plantToChangeDetails = plants.Any(g => g.PlantName == givenPlantName);
                if (!plantToChangeDetails)
                {
                    Console.WriteLine("error");
                    commands = Console.ReadLine().Split(": ");
                    continue;
                }
                Plant plantToChange = plants.First(g => g.PlantName == givenPlantName);
                if (commands[0] == "Rate")
                {
                    int ratingToAdd = int.Parse(commandDetails[1]);
                    plantToChange.Rating.Add(ratingToAdd);
                }
                else if (commands[0] == "Update")
                {
                    int newRarity = int.Parse(commandDetails[1]);
                    plantToChange.PlantRarity = newRarity;
                }
                else if (commands[0] == "Reset")
                {
                    plantToChange.Rating.Clear();
                }
                commands = Console.ReadLine().Split(": ");
            }
        }

        static void PrintPlantsDetails(List<Plant> plants)
        {
            Console.WriteLine("Plants for the exhibition:");
            foreach (Plant plant in plants)
            {
                if (plant.Rating.Count == 0)
                {
                    Console.WriteLine($"- {plant.PlantName}; Rarity: {plant.PlantRarity}; Rating: {0:f2}");
                }
                else
                {
                    Console.WriteLine($"- {plant.PlantName}; Rarity: {plant.PlantRarity}; Rating: {plant.Rating.Average():f2}");
                }
            }
        }
    }
    public class Plant
    {
        public Plant(string plantName, int rarity, List<int> rating)
        {
            PlantName = plantName;
            PlantRarity = rarity;
            Rating = rating;
        }
        public string PlantName { get; private set; }
        public int PlantRarity { get; set; }
        public List<int> Rating { get; private set; }
    }
}
