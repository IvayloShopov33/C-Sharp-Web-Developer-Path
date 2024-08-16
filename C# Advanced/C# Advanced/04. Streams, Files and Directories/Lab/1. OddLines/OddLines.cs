using System.IO;
using System;

namespace OddLines
{

    public class OddLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\Files\input.txt";
            string outputFilePath = @"..\..\..\Files\output.txt";

            ExtractOddLines(inputFilePath, outputFilePath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            using StreamReader input = new StreamReader(inputFilePath);
            using StreamWriter output = new StreamWriter(outputFilePath);

            int counter = 0;
            while (true)
            {
                string line = input.ReadLine();
                if (line == null)
                {
                    break;
                }

                //check if the line's number is odd
                if (counter % 2 == 1)
                {
                    output.WriteLine(line);
                    Console.WriteLine(line);
                }

                counter++;
            }
        }
    }
}
