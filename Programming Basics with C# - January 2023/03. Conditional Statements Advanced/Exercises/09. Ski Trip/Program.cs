using System;

namespace _09._Ski_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string typeOfRoom = Console.ReadLine();
            string assessment = Console.ReadLine();
            double price = 0;
            if (typeOfRoom=="room for one person")
            {
                price = (days - 1) * 18;
                if (assessment=="positive")
                {
                    price = price + price * 0.25;
                }
                else
                {
                    price = price - price * 0.1;
                }
            }
            else if (typeOfRoom=="apartment")
            {
                price = (days - 1) * 25;
                if (days<10)
                {

                    price = price - price * 0.3;
                }
                else if (days>=10 && days<=15)
                {
                    price = price - price * 0.35;
                }
                else
                {
                    price = price - price * 0.5;
                }
                if (assessment == "positive")
                {
                    price = price + price * 0.25;
                }
                else 
                {
                   price=price-price*0.1;
                }
            }
            else if (typeOfRoom=="president apartment")
            {
                price = (days - 1) * 35;
                if (days < 10)
                {

                    price = price - price * 0.1;
                }
                else if (days >= 10 && days <= 15)
                {
                    price = price - price * 0.15;
                }
                else
                {
                    price = price - price * 0.2;
                }
                if (assessment == "positive")
                {
                    price = price + price * 0.25;
                }
                else
                {
                    price = price - price * 0.1;
                }
            }
            Console.WriteLine($"{price:f2}");
        }
    }
}
