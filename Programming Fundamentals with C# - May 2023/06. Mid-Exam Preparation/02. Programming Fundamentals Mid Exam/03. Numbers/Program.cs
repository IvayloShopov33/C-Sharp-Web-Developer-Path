using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            double average = numbers.Average();
            numbers.RemoveAll(x => x <= average);
            if (numbers.Count > 0)
            {
                numbers.Sort();
                numbers.Reverse();
                if (numbers.Count >= 5)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        Console.Write(numbers[i] + " ");
                    }
                }
                else
                {
                    Console.WriteLine(string.Join(' ', numbers));
                }
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
