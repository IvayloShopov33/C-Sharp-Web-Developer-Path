using System;

namespace _12._Refactor_Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbersCount = int.Parse(Console.ReadLine());
            for (int i = 1; i <= numbersCount; i++)
            {
                int number = i;
                int sum = 0;
                while (number> 0)
                {
                    int digit = number % 10;
                    sum += digit;
                    number = number / 10;
                }
                if (sum==5 || sum==7 || sum==11)
                {
                    Console.WriteLine($"{i} -> True");
                }
                else
                {
                    Console.WriteLine($"{i} -> False");
                }
            }
        }
    }
}
