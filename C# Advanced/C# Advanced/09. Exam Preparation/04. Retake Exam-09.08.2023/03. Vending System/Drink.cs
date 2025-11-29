using System;
using System.Collections.Generic;
using System.Text;

namespace VendingSystem
{
    public class Drink
    {
        private string name;
        private decimal price;
        private int volume;

        public Drink(string name, decimal price, int volume)
        {
            this.Name = name;
            this.Price = price;
            this.Volume = volume;
        }

        public string Name { get { return name; } set { name = value; } }

        public decimal Price { get { return price; } set { price = value; } }

        public int Volume { get { return volume; } set { volume = value; } }

        public override string ToString()
        {
            return $"Name: {this.Name}, Price: ${this.Price}, Volume: {this.Volume} ml";
        }
    }
}
