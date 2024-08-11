using System;
using System.Text.RegularExpressions;

namespace _3._Match_Dates
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"(?<day>\d{2})(\.|-|/)(?<month>[A-Z][a-z]{2})\1(?<year>\d{4})";
            Regex regex = new Regex(pattern);
            MatchCollection matchCollectionOfValidDates = regex.Matches(input);
            foreach (Match match in matchCollectionOfValidDates)
            {
                Console.WriteLine($"Day: {match.Groups["day"]}, Month: {match.Groups["month"]}, Year: {match.Groups["year"]}");
            }
        }
    }
}
