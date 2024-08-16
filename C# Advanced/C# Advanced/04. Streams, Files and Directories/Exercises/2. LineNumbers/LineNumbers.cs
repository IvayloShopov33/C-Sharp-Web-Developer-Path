using System.IO;

namespace LineNumbers
{
    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            string[] lines = File.ReadAllLines(inputFilePath);
            string output = string.Empty;
            int linesCounter = 1;
            foreach (string line in lines)
            {
                int lettersCount = 0;
                int punctuationMarksCount = 0;
                foreach (char @char in line)
                {
                    if (char.IsLetter(@char))
                    {
                        lettersCount++;
                    }
                    else if (char.IsPunctuation(@char))
                    {
                        punctuationMarksCount++;
                    }
                }

                output += $"Line {linesCounter}: {line} ({lettersCount})({punctuationMarksCount})";
                output += "\n";
                linesCounter++;
            }

            File.WriteAllText(outputFilePath, output);
        }
    }
}
