﻿using System;

namespace _1._Sign_of_Integer_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            
            PositiveNegativeOrZero(number);
        }
        
        static void PositiveNegativeOrZero(int number)
        {
            if (number > 0)
                Console.WriteLine($"The number {number} is positive. ");
            else if (number < 0)
                Console.WriteLine($"The number {number} is negative. ");
            else
                Console.WriteLine($"The number {number} is zero. ");
        }
    }
}
