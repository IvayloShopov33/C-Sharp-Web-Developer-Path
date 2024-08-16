using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Food_Finder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = new string[4] { "pear", "flour", "pork", "olive" };
            Queue<char> vowels = new Queue<char>();
            Stack<char> consonants = new Stack<char>();
            char[] vowelsInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
            char[] consonantsInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

            foreach (char vowel in vowelsInput)
            {
                vowels.Enqueue(vowel);
            }

            foreach (char consonant in consonantsInput)
            {
                consonants.Push(consonant);
            }

            char[] firstWord = new char[words[0].Length];
            char[] secondWord = new char[words[1].Length];
            char[] thirdWord = new char[words[2].Length];
            char[] fourthWord = new char[words[3].Length];
            int firstWordLetterCount = 0, secondWordLetterCount = 0, thirdWordLetterCount = 0, fourthWordLetterCount = 0;

            while (consonants.Count > 0)
            {
                char vowel = vowels.Dequeue();
                char consonant = consonants.Pop();
                int index = 0;

                if (words[0].Contains(vowel))
                {
                    index = words[0].IndexOf(vowel);
                    if (!char.IsLetter(firstWord[index]))
                    {
                        firstWord[index] = vowel;
                        firstWordLetterCount++;
                    }
                }

                if (words[1].Contains(vowel))
                {
                    index = words[1].IndexOf(vowel);
                    if (!char.IsLetter(secondWord[index]))
                    {
                        secondWord[index] = vowel;
                        secondWordLetterCount++;
                    }
                }

                if (words[2].Contains(vowel))
                {
                    index = words[2].IndexOf(vowel);
                    if (!char.IsLetter(thirdWord[index]))
                    {
                        thirdWord[index] = vowel;
                        thirdWordLetterCount++;
                    }
                }

                if (words[3].Contains(vowel))
                {
                    index = words[3].IndexOf(vowel);
                    if (!char.IsLetter(fourthWord[index]))
                    {
                        fourthWord[index] = vowel;
                        fourthWordLetterCount++;
                    }
                }

                if (words[0].Contains(consonant))
                {
                    index = words[0].IndexOf(consonant);
                    if (!char.IsLetter(firstWord[index]))
                    {
                        firstWord[index] = consonant;
                        firstWordLetterCount++;
                    }
                }

                if (words[1].Contains(consonant))
                {
                    index = words[1].IndexOf(consonant);
                    if (!char.IsLetter(secondWord[index]))
                    {
                        secondWord[index] = consonant;
                        secondWordLetterCount++;
                    }
                }

                if (words[2].Contains(consonant))
                {
                    index = words[2].IndexOf(consonant);
                    if (!char.IsLetter(thirdWord[index]))
                    {
                        thirdWord[index] = consonant;
                        thirdWordLetterCount++;
                    }
                }

                if (words[3].Contains(consonant))
                {
                    index = words[3].IndexOf(consonant);
                    if (!char.IsLetter(fourthWord[index]))
                    {
                        fourthWord[index] = consonant;
                        fourthWordLetterCount++;
                    }
                }

                vowels.Enqueue(vowel);
            }

            StringBuilder output = new StringBuilder();
            int wordsFoundCount = 0;
            if (firstWordLetterCount == words[0].Length)
            {
                wordsFoundCount++;
                output.AppendLine(words[0]);
            }

            if (secondWordLetterCount == words[1].Length)
            {
                wordsFoundCount++;
                output.AppendLine(words[1]);
            }

            if (thirdWordLetterCount == words[2].Length)
            {
                wordsFoundCount++;
                output.AppendLine(words[2]);
            }

            if (fourthWordLetterCount == words[3].Length)
            {
                wordsFoundCount++;
                output.AppendLine(words[3]);
            }

            Console.WriteLine($"Words found: {wordsFoundCount}");
            if (wordsFoundCount > 0)
            {
                Console.WriteLine(output.ToString());
            }
        }
    }
}