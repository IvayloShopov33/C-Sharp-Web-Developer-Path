using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _4._Star_Enigma
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^[^\@\-\!\:\>]*@(?<planetName>[A-Za-z]+)[^\@\-\!\:\>]*:(?<planetPopulation>\d+)[^\@\-\!\:\>]*\!(?<attackType>A|D)\![^\@\-\!\:\>]*\-\>(?<soldiersCount>\d+)[^\@\-\!\:\>]*$";
            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();
            Regex regex = new Regex(pattern);

            DecryptingMessages(attackedPlanets, destroyedPlanets, regex);
            PrintAttackedAndDestroyedPlanets(attackedPlanets, destroyedPlanets);
        }

        static void DecryptingMessages(List<string> attackedPlanets, List<string> destroyedPlanets, Regex regex)
        {
            int messagesCount = int.Parse(Console.ReadLine());
            for (int i = 1; i <= messagesCount; i++)
            {
                string message = Console.ReadLine();
                char[] messageToCharArray = message.ToCharArray();
                int specialLettersCount = 0;

                foreach (char character in messageToCharArray)
                {
                    if (character == 's' || character == 't' || character == 'a' || character == 'r'
                        || character == 'S' || character == 'T' || character == 'A' || character == 'R')
                    {
                        specialLettersCount++;
                    }
                }

                StringBuilder decryptedMessage = new StringBuilder();
                foreach (char character in messageToCharArray)
                {
                    int characterASCIICode = character - specialLettersCount;
                    char newCharacter = (char)characterASCIICode;
                    decryptedMessage.Append(newCharacter);
                }

                Match match = regex.Match(decryptedMessage.ToString());
                if (match.Success)
                {
                    if (match.Groups["attackType"].Value == "A")
                    {
                        attackedPlanets.Add(match.Groups["planetName"].Value);
                    }
                    else if (match.Groups["attackType"].Value == "D")
                    {
                        destroyedPlanets.Add(match.Groups["planetName"].Value);
                    }
                }
            }
        }

        static void PrintAttackedAndDestroyedPlanets(List<string> attackedPlanets, List<string> destroyedPlanets)
        {
            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");
            if (attackedPlanets.Count > 0)
            {
                foreach (string planet in attackedPlanets.OrderBy(x => x))
                {
                    Console.WriteLine($"-> {planet}");
                }
            }

            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");
            if (destroyedPlanets.Count > 0)
            {
                destroyedPlanets.Sort();
                foreach (string planet in destroyedPlanets)
                {
                    Console.WriteLine($"-> {planet}");
                }
            }
        }
    }
}