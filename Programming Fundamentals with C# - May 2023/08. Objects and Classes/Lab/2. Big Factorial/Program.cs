﻿using System;
using System.Numerics;

namespace _2._Big_Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            BigInteger result = 1;
            
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            
            Console.WriteLine(result);
        }
    }
}
