using System;

namespace _03.Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            string typeOfGroup = Console.ReadLine();
            string day = Console.ReadLine();
            
            double price = 0;
            double totalPrice = 0;
            
            if (typeOfGroup == "Students")
            {
                if (day == "Friday")
                {
                    price = 8.45;
                    totalPrice = price * people;
                }
                else if (day == "Saturday")
                {
                    price = 9.8;
                    totalPrice = price * people;
                }
                else if (day == "Sunday")
                {
                    price = 10.46;
                    totalPrice = price * people;
                }
                
                if (people >= 30)
                {
                    totalPrice -= 0.15 * totalPrice;
                }
            }
            else if (typeOfGroup == "Business")
            {
                if (people >= 100)
                {
                    people -= 10;
                }
                
                if (day == "Friday")
                {
                    price = 10.9;
                    totalPrice = price * people;
                }
                else if (day == "Saturday")
                {
                    price = 15.6;
                    totalPrice = price * people;
                }
                else if (day == "Sunday")
                {
                    price = 16;
                    totalPrice = price * people;
                }               
            }
            else if (typeOfGroup == "Regular")
            {
                if (day == "Friday")
                {
                    price = 15;
                    totalPrice = price * people;
                }
                else if (day == "Saturday")
                {
                    price = 20;
                    totalPrice = price * people;
                }
                else if (day == "Sunday")
                {
                    price = 22.5;
                    totalPrice = price * people;
                }
                
                if (people >= 10 && people <= 20)
                {
                    totalPrice -= 0.05 * totalPrice;
                }
            }
            
            Console.WriteLine($"Total price: {totalPrice:f2}");
        }
    }
}
