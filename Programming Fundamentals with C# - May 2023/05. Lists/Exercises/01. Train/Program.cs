using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine().Split().Select(int.Parse).ToList();
            int maxPassengers = int.Parse(Console.ReadLine());
            string[] input = Console.ReadLine().Split();
            
            while (input[0] != "end")
            {
                if (input.Length == 2)
                {
                    wagons.Add(int.Parse(input[1]));
                }
                else
                {
                    for (int i = 0; i < wagons.Count; i++)
                    {
                        if (wagons[i] + int.Parse(input[0]) <= maxPassengers)
                        {
                            wagons[i] += int.Parse(input[0]);
                            break;
                        }
                    }
                }

                input = Console.ReadLine().Split();
            }
            
            Console.WriteLine(string.Join(' ', wagons));
        }
    }
}
