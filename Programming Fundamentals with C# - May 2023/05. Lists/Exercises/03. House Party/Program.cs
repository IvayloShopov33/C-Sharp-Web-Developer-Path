using System;
using System.Collections.Generic;

namespace _3._House_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int commandsCount = int.Parse(Console.ReadLine());
            string[] input;
            List<string> guest = new List<string>();
            
            for (int i = 1; i <= commandsCount; i++)
            {
                input = Console.ReadLine().Split();
                if (input.Length == 3)
                {
                    if (guest.Contains(input[0]))
                    {
                        Console.WriteLine($"{input[0]} is already in the list!");
                    }
                    else
                    {
                        guest.Add(input[0]);
                    }
                }
                else if (input.Length == 4)
                {
                    if (guest.Contains(input[0]))
                    {
                        guest.Remove(input[0]);
                    }
                    else
                    {
                        Console.WriteLine($"{input[0]} is not in the list!");
                    }
                }             
            }

            for (int i = 0; i < guest.Count; i++)
            {
                Console.WriteLine(guest[i]);
            }
        }
    }
}
