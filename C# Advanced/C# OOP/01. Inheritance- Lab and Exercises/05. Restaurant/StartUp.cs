using System;

namespace Restaurant
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Product fish = new Fish("Salmon", 10.50m);
            Product coffee = new Coffee("Latte", 50);
            Dessert cake = new Cake("Garash");
            HotBeverage tea = new Tea("Tea", 6, 100);

            Console.WriteLine(fish.Name);
            Console.WriteLine(coffee.Price);
            Console.WriteLine(cake.Calories);
            Console.WriteLine(tea.Milliliters);
        }
    }
}