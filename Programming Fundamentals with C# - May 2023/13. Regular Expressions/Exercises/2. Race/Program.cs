using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _2._Race
{
    class Program
    {
        static void Main(string[] args)
        {
            //First solution
            string[] participants = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, int> results =
                new Dictionary<string, int>();

            InitializeRacersWithTheirKilometers(participants, results);
            PrintFirstThreeRacers(results);


            //Second solution
            //string[] racers = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            //string input = Console.ReadLine();
            //Dictionary<string, int> racersWithTheirKilometers =
            //    new Dictionary<string, int>();
            //while (input != "end of race")
            //{
            //    string racerName = string.Empty;
            //    int kilometers = 0;
            //    foreach (char item in input)
            //    {
            //        if (char.IsLetter(item))
            //        {
            //            racerName += item;
            //        }
            //        else if (char.IsDigit(item))
            //        {
            //            kilometers += int.Parse(item.ToString());
            //        }
            //    }
            //    if (racers.Contains(racerName))
            //    {
            //        if (racersWithTheirKilometers.ContainsKey(racerName))
            //        {
            //            racersWithTheirKilometers[racerName] += kilometers;
            //        }
            //        else
            //        {
            //            racersWithTheirKilometers.Add(racerName, kilometers);
            //        }
            //    }
            //    input = Console.ReadLine();
            //}
            //racersWithTheirKilometers = racersWithTheirKilometers
            //    .OrderByDescending(g => g.Value)
            //    .Take(3)
            //    .ToDictionary(g => g.Key, g => g.Value);
            //Console.WriteLine($"1st place: {racersWithTheirKilometers.Keys.ElementAt(0)}");
            //Console.WriteLine($"2nd place: {racersWithTheirKilometers.Keys.ElementAt(1)}");
            //Console.WriteLine($"3rd place: {racersWithTheirKilometers.Keys.ElementAt(2)}");
        }

        static void InitializeRacersWithTheirKilometers(string[] participants, Dictionary<string, int> results)
        {
            foreach (string participant in participants)
            {
                results.Add(participant, 0);
            }

            string input;
            while ((input = Console.ReadLine()) != "end of race")
            {
                MatchCollection nameCollection = Regex.Matches(input, @"([A-Za-z]+)");
                MatchCollection kilometersCollection = Regex.Matches(input, @"(\d)");
                string name = string.Join(string.Empty, nameCollection);

                if (results.ContainsKey(name))
                {
                    results[name] += kilometersCollection.Select(x => int.Parse(x.Value)).Sum();
                }
            }
        }

        static void PrintFirstThreeRacers(Dictionary<string, int> results)
        {
            IEnumerable<KeyValuePair<string, int>> finalists = results.OrderByDescending(x => x.Value).Take(3);
            int counter = 1;

            foreach (KeyValuePair<string, int> finalist in finalists)
            {
                string suffix = counter == 1 ? "st" : counter == 2 ? "nd" : "rd";
                Console.WriteLine($"{counter}{suffix} place: {finalist.Key}");
                counter++;
            }
        }
    }
}