using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingSystem
{
    public class VendingMachine
    {
        private int buttonCapacity;
        private List<Drink> drinks;

        public VendingMachine(int buttonCapacity)
        {
            this.ButtonCapacity = buttonCapacity;
            this.Drinks = new List<Drink>();
        }

        public int ButtonCapacity { get { return buttonCapacity; } set { buttonCapacity = value; } }

        public List<Drink> Drinks { get { return drinks; } set { drinks = value; } }

        public int GetCount => this.Drinks.Count;

        public void AddDrink(Drink drink)
        {
            if (this.ButtonCapacity > this.Drinks.Count)
            {
                this.Drinks.Add(drink);
            }
        }

        public bool RemoveDrink(string name) => this.Drinks.Remove(this.Drinks.FirstOrDefault(x => x.Name == name));

        public Drink GetLongest() => this.Drinks.OrderByDescending(x => x.Volume).FirstOrDefault();

        public Drink GetCheapest() => this.Drinks.OrderBy(x => x.Price).FirstOrDefault();

        public string BuyDrink(string name) => this.Drinks.FirstOrDefault(x => x.Name == name).ToString();

        public string Report()
        {
            StringBuilder output = new();
            output.AppendLine("Drinks available:");

            foreach (Drink drink in drinks)
            {
                output.AppendLine(drink.ToString());
            }

            return output.ToString().TrimEnd();
        }
    }
}
