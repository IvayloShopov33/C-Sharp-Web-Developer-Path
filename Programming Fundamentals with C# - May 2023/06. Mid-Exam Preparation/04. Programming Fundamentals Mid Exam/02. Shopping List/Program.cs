using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Shopping_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> groceries = Console.ReadLine().Split('!').ToList();
            string[] input = Console.ReadLine().Split();
            
            while (input[0] != "Go" && input[1] != "Shopping!")
            {
                string item = input[1];
                if (input[0] == "Urgent")
                {
                    if (!groceries.Contains(item))
                    {
                        groceries.Insert(0, item);
                    }
                }
                else if (input[0] == "Unnecessary" && groceries.Contains(item))
                {
                    groceries.Remove(item);
                }
                else if (input[0] == "Correct" && groceries.Contains(item))
                {
                    string newItem = input[2];
                    int index = groceries.IndexOf(item);
                        
                    groceries.Insert(index + 1, newItem);
                    groceries.RemoveAt(index);
                }
                else if (groceries.Contains(item))
                {
                    groceries.Remove(item);
                    groceries.Add(item);
                }

                input = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join(", ", groceries));
        }
    }
}
