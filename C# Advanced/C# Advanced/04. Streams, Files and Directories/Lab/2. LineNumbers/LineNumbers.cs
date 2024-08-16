using System.IO;
using System;

namespace LineNumbers
{
    public class LineNumbers
    {
        static void Main()
        {
            string inputPath = @"..\..\..\Files\input.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            RewriteFileWithLineNumbers(inputPath, outputPath);
        }

        public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
        {
            using StreamReader input = new StreamReader(inputFilePath);
            using StreamWriter output = new StreamWriter(outputFilePath);

            //print all lines with a counter
            int counter = 0;
            while (!input.EndOfStream)
            {
                counter++;
                string line = input.ReadLine();
                string textToPrint = $"{counter}. {line}";
                output.WriteLine(textToPrint);
                Console.WriteLine(textToPrint);
            }
        }
    }
}
