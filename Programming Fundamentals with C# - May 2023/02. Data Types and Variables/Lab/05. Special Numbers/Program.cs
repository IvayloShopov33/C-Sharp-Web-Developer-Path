using System;

namespace _05._Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbersCount = int.Parse(Console.ReadLine());
            for (int i = 1; i <= numbersCount; i++)
            {
                int number = i;
                int numberCopy = number;
                int sumOfDigits = 0;
                while (number>0)
                {
                    int digit = number % 10;
                    sumOfDigits += digit;
                    number /= 10;
                }
                if (sumOfDigits==5 || sumOfDigits==7 || sumOfDigits==11) 
                {
                    Console.WriteLine($"{numberCopy} -> True");
                }
                else
                {
                    Console.WriteLine($"{numberCopy} -> False");
                }
            }
        }
    }
}
