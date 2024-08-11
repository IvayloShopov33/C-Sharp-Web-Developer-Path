using System;
using System.Collections.Generic;

namespace _2._Odd_Occurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();
            Dictionary<string, int> validWords =
                new Dictionary<string, int>();
            foreach (string word in words)
            {
                string wordToLowerCase = word.ToLower();
                if (!validWords.ContainsKey(wordToLowerCase))
                {
                    validWords.Add(wordToLowerCase, 1);
                }
                else
                {
                    validWords[wordToLowerCase]++;
                }
            }

            foreach (var word in validWords)
            {
                if (word.Value%2==1)
                {
                    Console.Write(word.Key+" ");
                }
            }
        }
    }
}
