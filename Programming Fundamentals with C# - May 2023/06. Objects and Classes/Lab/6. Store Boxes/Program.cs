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
            while (input[0]!="end")
            {
                string SerialNumber = input[0];
                string itemName = input[1];
                int ItemQuantity = int.Parse(input[2]);
                float ItemPrice=float.Parse(input[3]);
                Item item = new Item
                {
                    Name=itemName,
                    Price=ItemPrice
                };

                float priceOfTheBox = ItemQuantity * ItemPrice;
                Box box = new Box
                {
                    SerialNumber = SerialNumber,
                    Item = item,
                    ItemQuantity = ItemQuantity,
                    PriceOfTheBox = priceOfTheBox
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

     class Item
    {
        public string Name { get; set; }
        public float Price { get; set; }
    }

     class Box
    {
        public string SerialNumber { get; set; }
        public Item Item { get; set; }
        public int ItemQuantity { get; set; }
        public float PriceOfTheBox { get; set; }
    }
}
