using System;
using System.Collections.Generic;

namespace _1._Count_Chars_in_a_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();
            Dictionary<char, int> charsOccurences =
                new Dictionary<char, int>();
            foreach (string word in words)
            {
                char[] wordToCharArray = word.ToCharArray();
                for (int i = 0; i < wordToCharArray.Length; i++)
                {
                    if (!charsOccurences.ContainsKey(wordToCharArray[i]))
                    {
                        charsOccurences.Add(wordToCharArray[i], 0);
                    }
                    charsOccurences[wordToCharArray[i]]++;
                }
            }

            foreach (var character in charsOccurences)
            {
                Console.WriteLine($"{character.Key} -> {character.Value}");
            }
        }
    }
}
