using System;

namespace _11._Fruit_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string day = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());
            double price = 0;
            
            if (day == "Monday" || day == "Tuesday" || day == "Wednesday" || day == "Thursday" || day == "Friday")
            {
                if (fruit == "banana")
                {
                    price = 2.5;
                    double allPrice = quantity * price;
                    
                    Console.WriteLine($"{allPrice:f2}");
                }
                else if (fruit == "apple")
                {
                    price = 1.2;
                    double allPrice = quantity * price;
                    
                    Console.WriteLine($"{allPrice:f2}");
                }
                else if (fruit == "orange")
                {
                    price = 0.85;
                    double allPrice = quantity * price;
                    
                    Console.WriteLine($"{allPrice:f2}");
                }
                else if (fruit == "grapefruit")
                {
                    price = 1.45;
                    double allPrice = quantity * price;
                    
                    Console.WriteLine($"{allPrice:f2}");
                }
                else if (fruit == "kiwi")
                {
                    price = 2.7;
                    double allPrice = quantity * price;
                    
                    Console.WriteLine($"{allPrice:f2}");
                }
                else if (fruit == "pineapple")
                {
                    price = 5.5;
                    double allPrice = quantity * price;
                    
                    Console.WriteLine($"{allPrice:f2}");
                }
                else if (fruit == "grapes")
                {
                    price = 3.85;
                    double allPrice = quantity * price;
                    
                    Console.WriteLine($"{allPrice:f2}");
                }
                else
                {
                    Console.WriteLine("error");
                }               
            }
            else if (day == "Saturday" || day == "Sunday")
            {
                if (fruit == "banana")
                {
                    price = 2.7;
                    double allPrice = quantity * price;
                    
                    Console.WriteLine($"{allPrice:f2}");
                }
                else if (fruit == "apple")
                {
                    price = 1.25;
                    double allPrice = quantity * price;
                    
                    Console.WriteLine($"{allPrice:f2}");
                }
                else if (fruit == "orange")
                {
                    price = 0.9;
                    double allPrice = quantity * price;
                    
                    Console.WriteLine($"{allPrice:f2}");
                }
                else if (fruit == "grapefruit")
                {
                    price = 1.6;
                    double allPrice = quantity * price;
                    
                    Console.WriteLine($"{allPrice:f2}");
                }
                else if (fruit == "kiwi")
                {
                    price = 3;
                    double allPrice = quantity * price;
                    
                    Console.WriteLine($"{allPrice:f2}");
                }
                else if (fruit == "pineapple")
                {
                    price = 5.6;
                    double allPrice = quantity * price;
                    
                    Console.WriteLine($"{allPrice:f2}");
                }
                else if (fruit == "grapes")
                {
                    price = 4.2;
                    double allPrice = quantity * price;
                    
                    Console.WriteLine($"{allPrice:f2}");
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
