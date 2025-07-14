using System;
using System.Text.RegularExpressions;

namespace _2._Easter_Eggs
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(\@|\#)+(?<eggColor>[a-z]{3,})(\@|\#)+([^A-Za-z0-9])*(\/)+(?<amount>\d+)(\/)+";
            string inputText = Console.ReadLine();
            MatchCollection matchCollection = Regex.Matches(inputText, pattern);
            
            foreach (Match match in matchCollection)
            {
                string colorOfTheEgg = match.Groups["eggColor"].Value;
                int eggsQuantity = int.Parse(match.Groups["amount"].Value);
                
                Console.WriteLine($"You found {eggsQuantity} {colorOfTheEgg} eggs!");
            }
        }
    }
}
