using System;
using System.IO;

namespace MergeFiles
{
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            using StreamReader firstInput = new StreamReader(firstInputFilePath);
            using StreamReader secondInput = new StreamReader(secondInputFilePath);
            using StreamWriter output = new StreamWriter(outputFilePath);

            //merge two files' values, line by line into a third text file
            while (!firstInput.EndOfStream || !secondInput.EndOfStream)
            {
                if (!firstInput.EndOfStream)
                {
                    string firstLine = firstInput.ReadLine();
                    output.WriteLine(firstLine);
                    Console.WriteLine(firstLine);
                }

                if (!secondInput.EndOfStream)
                {
                    string secondLine = secondInput.ReadLine();
                    output.WriteLine(secondLine);
                    Console.WriteLine(secondLine);
                }
            }
        }
    }
}
