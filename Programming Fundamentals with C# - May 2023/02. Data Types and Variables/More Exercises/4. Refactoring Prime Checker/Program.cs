using System;

namespace _4._Refactoring_Prime_Checker_exception
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbersEnd = int.Parse(Console.ReadLine());
            for (int number = 2; number <= numbersEnd; number++)
            {
                string isPrime = "true";
                if (number % 2 == 0 && number != 2)
                {
                    isPrime = "false";
                }
                else
                {
                    for (int divisor = 2; divisor < number; divisor++)
                    {
                        if (number % divisor == 0)
                        {
                            isPrime = "false";
                        }
                    }
                }
                
                Console.WriteLine("{0} -> {1}", number, isPrime);
            }
        }
    }
}
