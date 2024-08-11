using System;
using System.Collections.Generic;

namespace _3._Hero_Recruitment
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> heroes =
                new Dictionary<string, List<string>>();
            ReceivingCommands(heroes);
            PrintHeroesWithTheirSpellNames(heroes);
        }

        static void ReceivingCommands(Dictionary<string, List<string>> heroes)
        {
            string[] commands = Console.ReadLine().Split();
            while (commands[0] != "End")
            {
                string action = commands[0];
                string heroName = commands[1];
                if (action == "Enroll")
                {
                    if (heroes.ContainsKey(heroName))
                    {
                        Console.WriteLine($"{heroName} is already enrolled.");
                    }
                    else
                    {
                        heroes.Add(heroName, new List<string>());
                    }
                }
                else
                {
                    string spellName = commands[2];
                    if (action == "Learn")
                    {
                        if (heroes.ContainsKey(heroName) && !heroes[heroName].Contains(spellName))
                        {
                            heroes[heroName].Add(spellName);
                        }
                        else if (!heroes.ContainsKey(heroName))
                        {
                            Console.WriteLine($"{heroName} doesn't exist.");
                        }
                        else if (heroes.ContainsKey(heroName) && heroes[heroName].Contains(spellName))
                        {
                            Console.WriteLine($"{heroName} has already learnt {spellName}.");
                        }
                    }
                    else if (action == "Unlearn")
                    {
                        if (heroes.ContainsKey(heroName) && heroes[heroName].Contains(spellName))
                        {
                            heroes[heroName].Remove(spellName);
                        }
                        else if (!heroes.ContainsKey(heroName))
                        {
                            Console.WriteLine($"{heroName} doesn't exist.");
                        }
                        else if (heroes.ContainsKey(heroName) && !heroes[heroName].Contains(spellName))
                        {
                            Console.WriteLine($"{heroName} doesn't know {spellName}.");
                        }
                    }
                }
                commands = Console.ReadLine().Split();
            }
        }

        static void PrintHeroesWithTheirSpellNames(Dictionary<string, List<string>> heroes)
        {
            Console.WriteLine("Heroes: ");
            foreach (KeyValuePair<string, List<string>> hero in heroes)
            {
                Console.WriteLine($"== {hero.Key}: {string.Join(", ", hero.Value)}");
            }
        }
    }
}
