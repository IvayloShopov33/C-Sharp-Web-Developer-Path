using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Car_Race
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int finishLine = (numbers.Count - 1) / 2;
            float sum = 0;
            float sum1 = 0;
            for (int i = 0; i < finishLine; i++)
            {
                if (numbers[i] == 0)
                {
                    sum *= 0.8f;
                }
                else
                {
                    sum += numbers[i];
                }
            }
            for (int i = numbers.Count-1; i > finishLine; i--)
            {
                if (numbers[i] == 0)
                {
                    sum1 *= 0.8f;
                }
                else
                {
                    sum1 += numbers[i];
                }
            }
            if (sum<sum1)
            {
                Console.WriteLine($"The winner is left with total time: {sum}");
            }
            else if (sum>sum1)
            {
                Console.WriteLine($"The winner is right with total time: {sum1}");
            }
        }
    }
}
