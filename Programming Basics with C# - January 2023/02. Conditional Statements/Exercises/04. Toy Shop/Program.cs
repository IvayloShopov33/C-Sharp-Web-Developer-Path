using System;

namespace _04._Toy_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            double priceTour = double.Parse(Console.ReadLine());
            int puzzles = int.Parse(Console.ReadLine());
            int dolls = int.Parse(Console.ReadLine());
            int bears = int.Parse(Console.ReadLine());
            int minions = int.Parse(Console.ReadLine());
            int trucks = int.Parse(Console.ReadLine());
            int toysQuantity = puzzles + dolls + bears + minions + trucks;
            double money = puzzles * 2.6 + dolls * 3 + bears * 4.1 + minions * 8.2 + trucks * 2;
            if(toysQuantity>=50)
            {
                money = money - money * 0.25;
            }
            money = money - money * 0.1;
            if (money>=priceTour)
            {
                Console.WriteLine($"Yes! {money-priceTour:f2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {priceTour-money:f2} lv needed.");
            }

        }
    }
}
