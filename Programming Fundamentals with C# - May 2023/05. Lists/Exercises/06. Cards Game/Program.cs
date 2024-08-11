using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Cards_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstCards = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> secondCards = Console.ReadLine().Split().Select(int.Parse).ToList();
            while(firstCards.Count>0 && secondCards.Count>0)
            {
                if (firstCards[0]>secondCards[0])
                {
                    firstCards.Add(secondCards[0]);
                    firstCards.Add(firstCards[0]);
                    firstCards.RemoveAt(0);
                    secondCards.RemoveAt(0);
                }
                else if (firstCards[0]<secondCards[0])
                {
                    secondCards.Add(firstCards[0]);
                    secondCards.Add(secondCards[0]);
                    secondCards.RemoveAt(0);
                    firstCards.RemoveAt(0);
                }
                else
                {
                    firstCards.RemoveAt(0);
                    secondCards.RemoveAt(0);
                }
            }
            if (firstCards.Count>0)
            {
                Console.WriteLine($"First player wins! Sum: {firstCards.Sum()}");
            }

            else
            {
                Console.WriteLine($"Second player wins! Sum: {secondCards.Sum()}");
            }
        }
    }
}
