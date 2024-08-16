using System;
using System.IO;

namespace EvenLines
{
    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            char[] charsToReplace = new char[5] { '-', ',', '.', '!', '?' };
            string output = string.Empty;
            using StreamReader streamReader = new StreamReader(inputFilePath);
            int linesCount = 0;
            while (!streamReader.EndOfStream)
            {
                string line = streamReader.ReadLine();
                if (linesCount % 2 == 0)
                {
                    foreach (char @char in charsToReplace)
                    {
                        line = line.Replace(@char, '@');
                    }

                    string[] words = line.Split();
                    for (int i = words.Length - 1; i >= 0; i--)
                    {
                        output += words[i] + " ";
                    }

                    output += "\n";
                }

                linesCount++;
            }

            return output;
        }
    }
}
