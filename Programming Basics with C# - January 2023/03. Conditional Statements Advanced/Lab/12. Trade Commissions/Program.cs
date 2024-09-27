using System;

namespace _12._Trade_Commissions
{
    class Program
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine();
            double sells = double.Parse(Console.ReadLine());
            double percent = 0;
            
            if (city == "Sofia")
            {
                if (sells >= 0 && sells <= 500)
                {
                    percent = 5;
                    double commission = percent / 100 * sells;
                    
                    Console.WriteLine($"{commission:f2}");
                }
                else if (sells > 500 && sells <= 1000)
                {
                    percent = 7;
                    double commission = percent / 100 * sells;
                    
                    Console.WriteLine($"{commission:f2}");
                }
                else if (sells > 1000 && sells <= 10000)
                {
                    percent = 8;
                    double commission = percent / 100 * sells;
                    
                    Console.WriteLine($"{commission:f2}");
                }
                else if (sells > 10000)
                {
                    percent = 12;
                    double commission = percent / 100 * sells;
                    
                    Console.WriteLine($"{commission:f2}");
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else if (city == "Varna")
            {
                if (sells >= 0 && sells <= 500)
                {
                    percent = 4.5;
                    double commission = percent / 100 * sells;
                    
                    Console.WriteLine($"{commission:f2}");
                }
                else if (sells > 500 && sells <= 1000)
                {
                    percent = 7.5;
                    double commission = percent / 100 * sells;
                    
                    Console.WriteLine($"{commission:f2}");
                }
                else if (sells > 1000 && sells <= 10000)
                {
                    percent = 10;
                    double commission = percent / 100 * sells;
                    
                    Console.WriteLine($"{commission:f2}");
                }
                else if (sells > 10000)
                {
                    percent = 13;
                    double commission = percent / 100 * sells;
                    
                    Console.WriteLine($"{commission:f2}");
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else if (city == "Plovdiv")
            {
                if (sells >= 0 && sells <= 500)
                {
                    percent = 5.5;
                    double commission = percent / 100 * sells;
                    
                    Console.WriteLine($"{commission:f2}");
                }
                else if (sells > 500 && sells <= 1000)
                {
                    percent = 8;
                    double commission = percent / 100 * sells;
                    
                    Console.WriteLine($"{commission:f2}");
                }
                else if (sells > 1000 && sells <= 10000)
                {
                    percent = 12;
                    double commission = percent / 100 * sells;
                    
                    Console.WriteLine($"{commission:f2}");
                }
                else if (sells > 10000)
                {
                    percent = 14.5;
                    double commission = percent / 100 * sells;
                    
                    Console.WriteLine($"{commission:f2}");
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else
            {
                Console.WriteLine("error");
            }            
        }
    }
}
