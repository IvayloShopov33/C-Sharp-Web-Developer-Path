using System;

namespace _10._Multiply_Evens_by_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int sumOfEven = GetSumOfEvenDigits(number);
            int sumOfOdd = GetSumOfOddDigits(number);
            int finalAnswer = GetMultipleOfEvenAndOdds(sumOfEven, sumOfOdd);
            Console.WriteLine(finalAnswer);
        }
        
        static int GetSumOfEvenDigits(int number)
        {
            int sumOfEven = 0;
            while (number!=0)
            {
                int digit = number % 10;
                if (digit%2==0)
                {
                    if (digit < 0)
                    {
                        digit = Math.Abs(digit);
                    }
                    sumOfEven += digit;
                }
                    number /= 10;
            }
            return sumOfEven;
        }
        static int GetSumOfOddDigits(int number)
        {
            int sumOfOdd = 0;
            while (number!=0)
            {
                int digit = number % 10;
                if (Math.Abs(digit%2)==1)
                {
                    if (digit < 0)
                    {
                        digit = Math.Abs(digit);
                    }
                    sumOfOdd += digit;
                }
                    number /= 10;
            }
            return sumOfOdd;
        }
        static int GetMultipleOfEvenAndOdds(int sumOfEven, int sumOfOdd)
        {
            int multipliedSums = sumOfEven * sumOfOdd;
            return multipliedSums;
        }
    }
}
