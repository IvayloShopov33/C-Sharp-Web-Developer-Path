using System;

namespace _07._Hotel_Room
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nightsNumber = int.Parse(Console.ReadLine());
            double price1 = 0;
            double price2 = 0;
            
            if (month=="May" || month=="October")
            {
                
                price1 = 50 * nightsNumber;
                if (nightsNumber>7 && nightsNumber<=14)
                {
                    price1 = price1 - price1 * 0.05;
                }
                else if (nightsNumber>14)
                {
                    price1 = price1 - price1 * 0.3;
                }
                price2 = 65 * nightsNumber;
                if (nightsNumber>14)
                {
                    price2 = price2 - price2 * 0.1;
                }
            }
            else if (month=="June" || month=="September")
            {
                price1 = 75.2 * nightsNumber;
                if (nightsNumber>14)
                {
                    price1 = price1 - price1 * 0.2;
                }
                price2 = 68.7 * nightsNumber;
                if (nightsNumber > 14)
                {
                    price2 = price2 - price2 * 0.1;
                }
            }
            else
            {
                price1 = 76 * nightsNumber;
                price2 = 77 * nightsNumber;
                if (nightsNumber > 14)
                {
                    price2 = price2 - price2 * 0.1;
                }
            }
            Console.WriteLine($"Apartment: {price2:f2} lv.");
            Console.WriteLine($"Studio: {price1:f2} lv.");
        }
    }
}
