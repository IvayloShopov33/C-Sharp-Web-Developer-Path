using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Gauss__Trick
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> newNumbers = new List<int>();
            for (int i = 0; i < numbers.Count/2; i++)
            {
                newNumbers.Add(numbers[i] + numbers[numbers.Count - 1 - i]);                
            }
            if (numbers.Count%2==1)
            {
                newNumbers.Add(numbers[numbers.Count / 2]);
            }
            Console.WriteLine(string.Join(' ', newNumbers));
        }
    }
}
