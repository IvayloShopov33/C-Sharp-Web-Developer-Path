using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Merging_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list1 = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> list2 = Console.ReadLine().Split().Select(int.Parse).ToList();
            int biggestCount = 0;
            int smallestCount = 0;
            if (list1.Count <= list2.Count)
            {
                biggestCount = list2.Count;
                smallestCount = list1.Count;
            }

            else
            {
                biggestCount = list1.Count;
                smallestCount = list2.Count;
            }

            List<int> finalList = new List<int>();

            for (int i = 0; i < smallestCount; i++)
            {
                finalList.Add(list1[i]);
                finalList.Add(list2[i]);
            }

            if (biggestCount == list2.Count)
            {
                for (int i = smallestCount; i < biggestCount; i++)
                {
                    finalList.Add(list2[i]);
                }

            }

            else
            {
                for (int i = smallestCount; i < biggestCount; i++)
                {
                    finalList.Add(list1[i]);
                }
            }
            Console.WriteLine(string.Join(' ', finalList));
        }

    }
}
