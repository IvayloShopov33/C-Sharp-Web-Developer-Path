using System;
using System.Collections.Generic;

namespace _3._Word_Synonyms
{
    class Program
    {
        static void Main(string[] args)
        {
            int wordsCount = int.Parse(Console.ReadLine());
            Dictionary<string, List<string>> synonyms =
                new Dictionary<string, List<string>>();
            for (int i = 1; i <= wordsCount; i++)
            {
                string key = Console.ReadLine();
                string value = Console.ReadLine();
                if (!synonyms.ContainsKey(key))
                {
                    synonyms.Add(key, new List<string>());
                }
                synonyms[key].Add(value);
            }

            foreach (var item in synonyms)
            {
                Console.WriteLine($"{item.Key} - {string.Join(", ", item.Value)}");
            }
        }
    }
}
