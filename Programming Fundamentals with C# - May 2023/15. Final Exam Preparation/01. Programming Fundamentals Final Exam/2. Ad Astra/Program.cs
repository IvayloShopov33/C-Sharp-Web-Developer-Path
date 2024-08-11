using System;
using System.Text.RegularExpressions;

namespace _2._Ad_Astra
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(\||#)(?<item>[A-Za-z\s]+)\1(?<date>\d{2}\/\d{2}\/\d{2})\1(?<calories>\d+)\1";
            string items = Console.ReadLine();
            MatchCollection matchCollection = Regex.Matches(items, pattern);
            int calories = 0;
            foreach (Match item in matchCollection)
            {
                calories += int.Parse(item.Groups["calories"].Value);
            }
            int days = calories / 2000;
            Console.WriteLine($"You have food to last you for: {days} days!");
            foreach (Match item in matchCollection)
            {
                Console.WriteLine($"Item: {item.Groups["item"]}, Best before: {item.Groups["date"]}, Nutrition: {item.Groups["calories"]}");
            }
        }
    }
}
