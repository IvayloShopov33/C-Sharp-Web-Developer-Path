using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Inventory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> items = Console.ReadLine().Split(", ").ToList();
            string[] input = Console.ReadLine().Split(" - ");
            
            while (input[0] != "Craft!")
            {
                string item = input[1];
                if (input[0] == "Collect")
                {
                    if (!items.Contains(item))
                    {
                        items.Add(item);
                    }
                }
                else if (input[0] == "Drop")
                {
                    if (items.Contains(item))
                    {
                        items.Remove(item);
                    }
                }
                else if (input[0] == "Combine Items")
                {
                    string[] combinedItems = item.Split(':');
                    string oldItem = combinedItems[0];
                    string newItem = combinedItems[1];
                    
                    if (items.Contains(oldItem))
                    {
                        int index = items.IndexOf(oldItem);
                        items.Insert(index + 1, newItem);
                    }
                }
                else if (input[0] == "Renew")
                {
                    if (items.Contains(item))
                    {
                        string renewedItem = item;
                        items.Remove(item);
                        items.Add(renewedItem);
                    }
                }

                input = Console.ReadLine().Split(" - ");
            }

            Console.WriteLine(string.Join(", ", items));
        }
    }
}
