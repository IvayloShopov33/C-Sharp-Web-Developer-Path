using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Hearth_Delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] houses = Console.ReadLine().Split('@').Select(int.Parse).ToArray();
            
            string[] input = Console.ReadLine().Split();
            int lastIndex = 0;
            int index = 0;
            while (input[0] != "Love!")
            {
                int length = int.Parse(input[1]);
                index += length;
                if (index < houses.Length)
                {
                    for (int i = 0; i < houses.Length; i++)
                    {
                        if (index == i)
                        {
                            lastIndex = i;
                            if (houses[i] == 0)
                                Console.WriteLine($"Place {i} already had Valentine's day.");

                            else
                            {
                                houses[i] -= 2;
                                if (houses[i]==0)
                                    Console.WriteLine($"Place {i} has Valentine's day.");
                            }
                            break;
                        }
                    }
                }

                else
                {
                    index = 0;
                    lastIndex = 0;
                    if (houses[0] == 0)
                        Console.WriteLine($"Place {0} already had Valentine's day.");

                    else
                    {
                        houses[0] -= 2;
                        if (houses[0] == 0)
                            Console.WriteLine($"Place {0} has Valentine's day.");
                    }
                }

                input = Console.ReadLine().Split();
            }

            Console.WriteLine($"Cupid's last position was {lastIndex}.");
            List<int> housesToList = houses.ToList();
            housesToList.RemoveAll(x => x == 0);
            if (housesToList.Count==0)
            {
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                Console.WriteLine($"Cupid has failed {housesToList.Count} places.");
            }
        }
    }
}
