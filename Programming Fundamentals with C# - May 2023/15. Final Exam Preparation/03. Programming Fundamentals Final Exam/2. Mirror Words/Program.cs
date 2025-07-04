using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _2._Mirror_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> mirrorWords =
                new Dictionary<string, string>();
            MatchCollection matchCollection = InitializeValidAndMirrorWords(mirrorWords);

            PrintMirrorWords(mirrorWords, matchCollection);
        }

        static MatchCollection InitializeValidAndMirrorWords(Dictionary<string, string> mirrorWords)
        {
            string pattern = @"(\#|\@)(?<firstWord>[A-Za-z]){3,}\1\1(?<secondWord>[A-Za-z]){3,}\1";
            string input = Console.ReadLine();
            MatchCollection matchCollection = Regex.Matches(input, pattern);

            foreach (Match match in matchCollection)
            {
                CaptureCollection firstWordCaptures = match.Groups["firstWord"].Captures;
                string firstWord = string.Empty;

                foreach (var item in firstWordCaptures)
                {
                    firstWord += item;
                }

                CaptureCollection secondWordCaptures = match.Groups["secondWord"].Captures;
                string secondWord = string.Empty;

                foreach (var item in secondWordCaptures)
                {
                    secondWord += item;
                }

                char[] secondWordToCharArray = secondWord.ToCharArray();
                string mirrorWord = string.Empty;

                for (int i = secondWordToCharArray.Length - 1; i >= 0; i--)
                {
                    mirrorWord += secondWordToCharArray[i];
                }

                if (firstWord == mirrorWord)
                {
                    mirrorWords.Add(firstWord, secondWord);
                }
            }

            return matchCollection;
        }

        static void PrintMirrorWords(Dictionary<string, string> mirrorWords, MatchCollection matchCollection)
        {
            if (matchCollection.Count > 0)
            {
                Console.WriteLine($"{matchCollection.Count} word pairs found!");
            }
            else
            {
                Console.WriteLine("No word pairs found!");
            }

            if (mirrorWords.Count > 0)
            {
                Console.WriteLine("The mirror words are:");
                int count = 0;

                foreach (KeyValuePair<string, string> item in mirrorWords)
                {
                    string textToPrint = $"{item.Key} <=> {item.Value}, ";
                    count++;

                    if (mirrorWords.Count == count)
                    {
                        textToPrint = textToPrint.Remove(textToPrint.Length - 2);
                    }

                    Console.Write(textToPrint);
                }
            }
            else
            {
                Console.WriteLine($"No mirror words!");
            }
        }
    }
}