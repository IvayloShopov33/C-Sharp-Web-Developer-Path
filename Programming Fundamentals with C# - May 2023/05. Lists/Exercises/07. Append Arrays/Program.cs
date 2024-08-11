using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._Append_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> numbers = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries).ToList();
            numbers.Reverse();
            string numbersString = string.Empty;
            for (int i = 0; i < numbers.Count; i++)
            {
                numbersString += numbers[i] + " ";
            }
            List<int> numbersInt = numbersString.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            Console.WriteLine(String.Join(' ', numbersInt));
        }
    }
}
