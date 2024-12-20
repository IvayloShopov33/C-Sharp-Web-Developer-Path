using System;

namespace _3.GamingStore_exceptio
{
    class Program
    {
        static void Main(string[] args)
        {
            double balanceOfMoney = double.Parse(Console.ReadLine());
            string game = Console.ReadLine();
            
            double price = 0;
            double spentMoney = 0;
            bool flag;
            bool flag1 = false;
            
            while (game != "Game Time")
            {
                flag = false;
                if (game == "OutFall 4")
                    price = 39.99;
                else if (game == "CS: OG")
                    price = 15.99;
                else if (game == "Zplinter Zell")
                    price = 19.99;
                else if (game == "Honored 2")
                    price = 59.99;
                else if (game == "RoverWatch")
                    price = 29.99;
                else if (game == "RoverWatch Origins Edition")
                    price = 39.99;
                else
                {
                    Console.WriteLine("Not Found");
                    flag = true;
                }
                
                if (balanceOfMoney < price && !flag)
                {
                    Console.WriteLine("Too Expensive");
                }
                else if (balanceOfMoney >= price && !flag)
                {
                    balanceOfMoney -= price;
                    spentMoney += price;
                    
                    if (balanceOfMoney <= 0)
                    {
                        Console.WriteLine("Out of money!");
                        flag1 = true;
                    }
                    else
                    {
                        Console.WriteLine($"Bought {game}");
                    }
                }
                
                game = Console.ReadLine();
            }
            
            if (!flag1)
                Console.WriteLine($"Total spent: ${spentMoney:f2}. Remaining: ${balanceOfMoney:f2}");
        }
    }
}
