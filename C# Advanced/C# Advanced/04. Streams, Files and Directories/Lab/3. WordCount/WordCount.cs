using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WordCount
{
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            using StreamReader inputWords = new StreamReader(wordsFilePath);
            using StreamReader inputText = new StreamReader(textFilePath);
            using StreamWriter outputText = new StreamWriter(outputFilePath);

            Dictionary<string, int> wordsWithTheirOccurrencesCount = new Dictionary<string, int>();
            string[] words = inputWords.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (!inputText.EndOfStream)
            {
                string line = inputText.ReadLine();           
                string[] lineWords = line.Split(' ', '-', '.', ',', '!', '?', ';', ':', StringSplitOptions.RemoveEmptyEntries);
             
                for (int i = 0; i < lineWords.Length; i++)
                {
                    // check if the array of words contains the current word from input lines
                    if (words.Contains(lineWords[i]))
                    {
                        // add the word to the dictionary or increase its occurrences' count
                        if (!wordsWithTheirOccurrencesCount.ContainsKey(lineWords[i]))
                        {
                            wordsWithTheirOccurrencesCount.Add(lineWords[i], 0);
                        }

                        wordsWithTheirOccurrencesCount[lineWords[i]]++;
                    }
                }
            }

            // print all words with their occurrences's count, sorted by frequency in descending order
            foreach (var word in wordsWithTheirOccurrencesCount.OrderByDescending(x => x.Value))
            {
                string output = $"{word.Key} - {word.Value}";
                outputText.WriteLine(output);
                Console.WriteLine(output);
            }
        }
    }
}