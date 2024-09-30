using System;

namespace _03._New_House
{
    class Program
    {
        static void Main(string[] args)
        {
            string flowers = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());
            double price = 0;
            
            if (flowers == "Roses")
            {
                price = 5;
                price *= quantity;
                
                if (quantity > 80)
                {
                    price -= price * 0.1;
                }
                
                if (budget >= price)
                {
                    Console.Write($"Hey, you have a great garden with {quantity} {flowers} and {budget-price:f2} leva left.");
                }
                else
                {
                    Console.Write($"Not enough money, you need {price-budget:f2} leva more.");
                }
            }
            else if (flowers == "Dahlias")
            {
                price = 3.8;
                price *= quantity;
                
                if (quantity > 90)
                {
                    price -= price * 0.15;
                }
                
                if (budget >= price)
                {
                    Console.Write($"Hey, you have a great garden with {quantity} {flowers} and {budget - price:f2} leva left.");
                }
                else
                {
                    Console.Write($"Not enough money, you need {price - budget:f2} leva more.");
                }
            }
            else if (flowers == "Tulips")
            {
                price = 2.8;
                price *= quantity;
                
                if (quantity > 80)
                {
                    price -= price * 0.15;
                }
                
                if (budget >= price)
                {
                    Console.Write($"Hey, you have a great garden with {quantity} {flowers} and {budget - price:f2} leva left.");
                }
                else
                {
                    Console.Write($"Not enough money, you need {price - budget:f2} leva more.");
                }
            }
           else if (flowers == "Narcissus")
            {
                price = 3;
                price *= quantity;
               
                if (quantity < 120)
                {
                    price += price * 0.15;
                }
               
                if (budget >= price)
                {
                    Console.Write($"Hey, you have a great garden with {quantity} {flowers} and {budget - price:f2} leva left.");
                }
                else
                {
                    Console.Write($"Not enough money, you need {price - budget:f2} leva more.");
                }
            }
            else
            {
                price = 2.5;
                price *= quantity;
                
                if (quantity < 80)
                {
                    price += price * 0.2;
                }
                
                if (budget >= price)
                {
                    Console.Write($"Hey, you have a great garden with {quantity} {flowers} and {budget - price:f2} leva left.");
                }
                else
                {
                    Console.Write($"Not enough money, you need {price - budget:f2} leva more.");
                }
            }
        }
    }
}
