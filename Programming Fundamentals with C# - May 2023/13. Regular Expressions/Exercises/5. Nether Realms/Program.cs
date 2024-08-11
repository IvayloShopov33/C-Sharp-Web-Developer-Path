using System;
using System.Text.RegularExpressions;

namespace _5._Nether_Realms
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = InitializeDemons();
            InitializeAndPrintDemonsDetails(input);
        }

        static string[] InitializeDemons()
        {
            string[] input = Console.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < input.Length; i++)
            {
                input[i] = input[i].Replace(" ", "");
            }
            Array.Sort(input);
            return input;
        }

        static void InitializeAndPrintDemonsDetails(string[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                MatchCollection matchCollectionOfHealth = Regex.Matches(input[i], @"[^0-9+\-*/.\s]");
                int health = 0;
                foreach (Match match in matchCollectionOfHealth)
                {
                    char character = char.Parse(match.Value);
                    health += character;
                }
                MatchCollection matchCollectionOfDamage = Regex.Matches(input[i], @"([\+|\-]*\d+(\.\d+)?)");
                double damage = 0;
                foreach (Match match in matchCollectionOfDamage)
                {
                    damage += double.Parse(match.Value);
                }
                foreach (char character in input[i])
                {
                    if (character == '*')
                    {
                        damage *= 2;
                    }
                    else if (character == '/')
                    {
                        damage /= 2;
                    }
                }
                Console.WriteLine($"{input[i]} - {health} health, {damage:f2} damage");
            }
        }
    }
}
