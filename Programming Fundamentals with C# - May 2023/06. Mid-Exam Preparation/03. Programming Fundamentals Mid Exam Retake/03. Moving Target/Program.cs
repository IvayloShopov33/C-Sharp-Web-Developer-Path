using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Moving_Target
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine().Split().Select(int.Parse).ToList();
            string[] actions = Console.ReadLine().Split();
            
            while (actions[0] != "End")
            {
                int index = int.Parse(actions[1]);
                if (actions[0] == "Add")
                {
                    if (index >= 0 && index < targets.Count)
                    {
                        int @value = int.Parse(actions[2]);
                        targets.Insert(index, @value);
                    }
                    else
                    {
                        Console.WriteLine("Invalid placement!");
                    }
                }
                else if (actions[0] == "Shoot")
                {
                    if (index >= 0 && index < targets.Count)
                    {
                        int power = int.Parse(actions[2]);
                        if (targets[index] <= power)
                        {
                            targets.RemoveAt(index);
                        }
                        else
                        {
                            targets[index] -= power;
                        }
                    }
                }
                else if (actions[0] == "Strike")
                {
                    int radius = int.Parse(actions[2]);
                    int startIndex = index - radius;
                    int endIndex = index + radius;
                    
                    if (startIndex >= 0 && endIndex < targets.Count)
                    {
                        targets.RemoveRange(startIndex, endIndex - startIndex + 1);
                    }
                    else
                    {
                        Console.WriteLine("Strike missed!");
                    }
                }
                
                actions = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join('|', targets));
        }
    }
}
