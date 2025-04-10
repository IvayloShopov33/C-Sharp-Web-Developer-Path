using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Store_Boxes
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            List<Box> boxes = new List<Box>();
            
            while (input[0] != "end")
            {
                string serialNumber = input[0];
                string itemName = input[1];
                int itemQuantity = int.Parse(input[2]);
                float itemPrice = float.Parse(input[3]);
                
                Item item = new Item
                {
                    Name = itemName,
                    Price = itemPrice,
                };

                float priceOfTheBox = itemQuantity * itemPrice;
                Box box = new Box
                {
                    SerialNumber = serialNumber,
                    Item = item,
                    ItemQuantity = itemQuantity,
                    PriceOfTheBox = priceOfTheBox,
                };
                
                boxes.Add(box);
                input = Console.ReadLine().Split();
            }

            foreach (var box in boxes.OrderByDescending(x=> x.PriceOfTheBox))
            {
                Console.WriteLine(box.SerialNumber);
                Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:f2}: {box.ItemQuantity}");
                Console.WriteLine($"-- ${box.PriceOfTheBox:f2}");
            }
        }
    }

    public class Item
    {
        public string Name { get; set; }
         
        public float Price { get; set; }
    }

    public class Box
    {
        public string SerialNumber { get; set; }
         
        public Item Item { get; set; }
         
        public int ItemQuantity { get; set; }
         
        public float PriceOfTheBox { get; set; }
    }
}
