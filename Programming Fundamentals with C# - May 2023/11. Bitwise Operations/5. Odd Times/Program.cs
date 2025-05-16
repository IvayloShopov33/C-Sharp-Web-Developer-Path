using System;
using System.Linq;

namespace _5._Odd_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int i = 0; i < numbers.Length; i++)
            {
                int count = 0;
                for (int j = i; j < numbers.Length; j++)
                {
                    if (numbers[i] == numbers[j])
                    {
                        count++;
                    }
                }
                
                if (count % 2 == 1)
                {
                    Console.WriteLine(numbers[i]);
                    return;
                }
            }
        }
    }
}
