using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Mixed_Up_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstNumbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> secondNumbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            
            List<int> finalNumbers = new List<int>();
            List<int> borders = new List<int>();
            
            if (firstNumbers.Count > secondNumbers.Count)
            {
                for (int i = 0; i < secondNumbers.Count; i++)
                {
                    finalNumbers.Add(firstNumbers[i]);
                    finalNumbers.Add(secondNumbers[secondNumbers.Count - 1 - i]);
                }
                
                borders.Add(firstNumbers[firstNumbers.Count - 1]);
                borders.Add(firstNumbers[firstNumbers.Count - 2]);
                borders.Sort();
                
                for (int i = 0; i < finalNumbers.Count; i++)
                {
                    if (finalNumbers[i] <= borders[0] || finalNumbers[i] >= borders[1])
                    {
                        finalNumbers.Remove(finalNumbers[i]);
                        i--;
                    }
                }
                
                finalNumbers.Sort();
                Console.WriteLine(string.Join(' ', finalNumbers));
            }
            else if (firstNumbers.Count < secondNumbers.Count)
            {
                for (int i = 0; i < firstNumbers.Count; i++)
                {
                    finalNumbers.Add(firstNumbers[i]);
                    finalNumbers.Add(secondNumbers[secondNumbers.Count - 1 - i]);
                }
                
                borders.Add(secondNumbers[0]);
                borders.Add(secondNumbers[1]);
                borders.Sort();
                
                for (int i = 0; i < finalNumbers.Count; i++)
                {
                    if (finalNumbers[i] <= borders[0] || finalNumbers[i] >= borders[1])
                    {
                        finalNumbers.Remove(finalNumbers[i]);
                        i--;
                    }
                }
                
                finalNumbers.Sort();
                Console.WriteLine(string.Join(' ', finalNumbers));
            }
        }
    }
}
