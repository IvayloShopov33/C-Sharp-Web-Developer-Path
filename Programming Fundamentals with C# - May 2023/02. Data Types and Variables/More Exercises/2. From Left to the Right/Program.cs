using System;
using System.Linq;
using System.Numerics;

namespace _2._From_Left_to_the_Right_exception
{
    class Program
    {
        static void Main(string[] args)
        {
            int linesCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < linesCount; i++)
            {
                string[] numbers = Console.ReadLine().Split(' ');
                long number1 = long.Parse(numbers[0]);
                long number2 = long.Parse(numbers[1]);
                long sum = 0;
                
                if (number1 > number2)
                {
                    while (number1 != 0)
                    {
                        long digit = Math.Abs(number1 % 10);
                        sum += digit;
                        number1 = Math.Abs(number1) / 10;
                    }
                }
                else
                {
                    while (number2 != 0)
                    {
                        long digit = Math.Abs(number2 % 10);
                        sum += digit;
                        number2 = Math.Abs(number2) / 10;
                    }
                }
                
                Console.WriteLine(Math.Abs(sum));
            }
        }
    }
}
