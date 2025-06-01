using System;
using System.Text;

namespace _8._Letters_Change_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputStrings = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            double totalSum = 0;

            for (int i = 0; i < inputStrings.Length; i++)
            {
                StringBuilder inputString = new StringBuilder();
                inputString.Append(inputStrings[i]);

                double number = 0;
                char lastLetter = inputString[inputString.Length - 1];
                double letterInAlphabet = 0;

                if (char.IsUpper(inputString[0]))
                {
                    letterInAlphabet = inputString[0] - 'A' + 1;
                    inputString = inputString.Remove(0, 1);
                    inputString = inputString.Remove(inputString.Length - 1, 1);

                    int inputNumber = int.Parse(inputString.ToString());
                    number = inputNumber / letterInAlphabet;
                }
                else
                {
                    letterInAlphabet = inputString[0] - 'a' + 1;
                    inputString = inputString.Remove(0, 1);
                    inputString = inputString.Remove(inputString.Length - 1, 1);

                    int inputNumber = int.Parse(inputString.ToString());
                    number = inputNumber * letterInAlphabet;
                }

                double lastLetterPositionInAlphabet = 0;
                if (char.IsUpper(lastLetter))
                {
                    lastLetterPositionInAlphabet = lastLetter - 'A' + 1;
                    number -= lastLetterPositionInAlphabet;
                }
                else
                {
                    lastLetterPositionInAlphabet = lastLetter - 'a' + 1;
                    number += lastLetterPositionInAlphabet;
                }

                totalSum += number;
            }

            Console.WriteLine($"{totalSum:f2}");
        }
    }
}