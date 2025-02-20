using System;

namespace _08._Factorial_Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            
            decimal factorialOfTheFirstNumber = GetFactorialOfTheNumber(firstNumber);
            decimal factorialOfTheSecondNumber = GetFactorialOfTheNumber(secondNumber);
            
            decimal finalResult = factorialOfTheFirstNumber / factorialOfTheSecondNumber;
            Console.WriteLine($"{finalResult:f2}");
        }
        
        static decimal GetFactorialOfTheNumber(int number)
        {
            decimal result = 1;
            for (int i = 2; i <= number; i++)
            {
                result *= i;
            }

            return result;
        }
    }
}
