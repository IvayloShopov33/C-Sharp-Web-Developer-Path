using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _2._Destination_Mapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(\=|\/)(?<Destination>[A-Z]([A-Za-z]+){2,})\1";
            string input = Console.ReadLine();
            MatchCollection matchCollection = Regex.Matches(input, pattern);
            int travelPoints = 0;
            List<string> destionations = new List<string>();
            foreach (Match match in matchCollection)
            {
                travelPoints += match.Groups["Destination"].Value.Length;
                destionations.Add(match.Groups["Destination"].Value);
            }
            Console.WriteLine($"Destinations: {string.Join(", ", destionations)}");
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}
