using System;

namespace _2._Character_Multiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] strings = Console.ReadLine().Split();
            string firstString = strings[0];
            string secondString = strings[1];
            int sum = 0;

            if (firstString.Length > secondString.Length)
            {
                sum = SumWhenFirstLengthIsBigger(firstString, secondString, sum);
            }
            else if (firstString.Length < secondString.Length)
            {
                sum = SumWhenSecondLengthIsBigger(firstString, secondString, sum);
            }
            else if (firstString.Length == secondString.Length)
            {
                sum = SumWhenLengthsAreEqual(firstString, secondString, sum);
            }

            PrintTotalSumOfCharacters(sum);
        }

        static int SumWhenFirstLengthIsBigger(string firstString, string secondString, int sum)
        {
            for (int i = 0; i < secondString.Length; i++)
            {
                sum += firstString[i] * secondString[i];
            }

            for (int i = secondString.Length; i < firstString.Length; i++)
            {
                sum += firstString[i];
            }

            return sum;
        }

        static int SumWhenSecondLengthIsBigger(string firstString, string secondString, int sum)
        {
            for (int i = 0; i < firstString.Length; i++)
            {
                sum += firstString[i] * secondString[i];
            }

            for (int i = firstString.Length; i < secondString.Length; i++)
            {
                sum += secondString[i];
            }

            return sum;
        }

        static int SumWhenLengthsAreEqual(string firstString, string secondString, int sum)
        {
            for (int i = 0; i < firstString.Length; i++)
            {
                sum += firstString[i] * secondString[i];
            }

            return sum;
        }

        static void PrintTotalSumOfCharacters(int sum)
        {
            Console.WriteLine(sum);
        }
    }
}