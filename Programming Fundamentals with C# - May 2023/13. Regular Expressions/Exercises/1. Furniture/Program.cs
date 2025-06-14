using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _1._Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> furnitures = new List<string>();
            double totalSum = 0;

            totalSum = InitializeValidFurnitures(furnitures, totalSum);
            PrintValidFurnituresWithTotalSum(furnitures, totalSum);
        }

        static double InitializeValidFurnitures(List<string> furnitures, double totalSum)
        {
            string input = Console.ReadLine();
            string pattern = @"^>>(?<furnitureName>[A-Za-z]+)<<(?<price>\d+(\.\d+)?)!(?<quantity>\d+)(\.\d+)?$";

            while (input != "Purchase")
            {
                Match match = Regex.Match(input, pattern);
                if (match.Success)
                {
                    string furnitureName = match.Groups["furnitureName"].Value;
                    furnitures.Add(furnitureName);

                    double pricePerUnit = double.Parse(match.Groups["price"].Value);
                    int quantity = int.Parse(match.Groups["quantity"].Value);
                    totalSum += pricePerUnit * quantity;
                }

                input = Console.ReadLine();
            }

            return totalSum;
        }

        static void PrintValidFurnituresWithTotalSum(List<string> furnitures, double totalSum)
        {
            Console.WriteLine("Bought furniture:");
            if (furnitures.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, furnitures));
            }

            Console.WriteLine($"Total money spend: {totalSum:f2}");
        }
    }
}