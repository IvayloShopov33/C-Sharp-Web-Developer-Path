using System;

namespace _7._Vending_Machine
{
    class Program
    {
        static void Main(string[] args)
        {
            string coins = Console.ReadLine();
            double sumOfMoney = 0;
            bool flag = false;
            
            while (coins != "Start")
            {
                double money = double.Parse(coins);
                if (money == 0.1 || money == 0.2 || money == 0.5 || money == 1 || money == 2)
                {
                    sumOfMoney += money;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {money}");
                }
                
                coins = Console.ReadLine();
            }
            
            string product = Console.ReadLine();
            double price = 0;
            
            while (product != "End")
            {
                if (product == "Nuts")
                {
                    price = 2.0;
                }
                else if (product == "Water")
                {
                    price = 0.7;
                }
                else if (product == "Crisps")
                {
                    price = 1.5;
                }
                else if (product == "Soda")
                {
                    price = 0.8;
                }
                else if (product == "Coke")
                {
                    price = 1.0;
                }
                else
                {
                    flag = true;
                    Console.WriteLine("Invalid product");
                }

                if (sumOfMoney >= price && !flag)
                {
                    sumOfMoney -= price;
                    Console.WriteLine($"Purchased {product.ToLower()}");
                }
                else if (sumOfMoney < 0 && !flag)
                {
                    Console.WriteLine("Sorry, not enough money");
                }

                product = Console.ReadLine();
            }
            
            Console.WriteLine($"Change: {sumOfMoney:f2}");
        }
    }
}
