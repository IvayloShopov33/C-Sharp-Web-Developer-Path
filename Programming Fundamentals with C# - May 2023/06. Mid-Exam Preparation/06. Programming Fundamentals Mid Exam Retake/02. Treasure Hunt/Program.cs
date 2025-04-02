using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Treasure_Hunt
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> lootOfTheChest = Console.ReadLine().Split('|').ToList();
            string[] input = Console.ReadLine().Split();
            
            while (input[0] != "Yohoho!")
            {
                if (input[0] == "Loot")
                {
                    string[] newItemsLoot = new string[input.Length - 1];
                    for (int i = 1; i < input.Length; i++)
                    {
                        newItemsLoot[i - 1] = input[i];
                    }

                    for (int i = 0; i < newItemsLoot.Length; i++)
                    {
                        if (!lootOfTheChest.Contains(newItemsLoot[i]))
                        {
                            lootOfTheChest.Insert(0, newItemsLoot[i]);
                        }
                    }
                }
                else if (input[0] == "Drop")
                {
                    int index = int.Parse(input[1]);
                    if (index >= 0 && index < lootOfTheChest.Count)
                    {
                        string item = lootOfTheChest[index];
                        lootOfTheChest.RemoveAt(index);
                        lootOfTheChest.Add(item);
                    }
                }
                else if (input[0] == "Steal")
                {
                    int count = int.Parse(input[1]);
                    string[] stolenItems;
                    
                    if (count <= lootOfTheChest.Count)
                    {
                        stolenItems = new string[count];
                        int index = 0;
                        
                        for (int i = lootOfTheChest.Count - count; i < lootOfTheChest.Count; i++)
                        {
                            stolenItems[index] = lootOfTheChest[i];
                            index++;
                        }
                        
                        lootOfTheChest.RemoveRange(lootOfTheChest.Count - count, count);
                    }
                    else
                    {
                        stolenItems = lootOfTheChest.ToArray();
                        lootOfTheChest.Clear();
                    }

                    Console.WriteLine(string.Join(", ", stolenItems));
                }

                input = Console.ReadLine().Split();
            }

            if (lootOfTheChest.Count > 0)
            {
                string singleItem;
                int sumOfChars = 0;
                
                for (int i = 0; i < lootOfTheChest.Count; i++)
                {
                    singleItem = lootOfTheChest[i];
                    sumOfChars += singleItem.Length;
                }
                
                int count = lootOfTheChest.Count;
                double averageGain = sumOfChars * 1.0 / count;
                Console.WriteLine($"Average treasure gain: {averageGain:f2} pirate credits.");
            }
            else
            {
                Console.WriteLine("Failed treasure hunt.");
            }
        }
    }
}
