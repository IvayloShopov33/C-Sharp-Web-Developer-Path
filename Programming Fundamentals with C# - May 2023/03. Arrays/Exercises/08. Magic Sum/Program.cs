using System;
using System.Linq;

namespace _8._Magic_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayOfNumbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int number = int.Parse(Console.ReadLine());
            for (int i = 0; i < arrayOfNumbers.Length; i++)
            {
                for (int j = i+1; j < arrayOfNumbers.Length; j++)
                {
                    if (arrayOfNumbers[i]+arrayOfNumbers[j]==number)
                    {
                        Console.Write($"{arrayOfNumbers[i]} {arrayOfNumbers[j]}");
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
