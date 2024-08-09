using System;

namespace _05._Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            double price = 0;
            string typeOfHoliday = "";
            string destination = "";
            if (budget<=100)
            {
                 destination = "Bulgaria";
                if (season=="summer")
                {
                    price = budget * 0.3;
                    typeOfHoliday = "Camp";

                }
                else if (season=="winter")
                {
                    price = 0.7 * budget;
                    typeOfHoliday = "Hotel";
                }
            }
            else if (budget>100 && budget<=1000)
            {
                destination = "Balkans";
                if (season=="summer")
                {
                    price = 0.4 * budget;
                    typeOfHoliday = "Camp";
                }
                else if (season=="winter")
                {
                    price = 0.8 * budget;
                    typeOfHoliday = "Hotel";
                }
            }
            else
            {
                destination = "Europe";
                price = 0.9 * budget;
                typeOfHoliday = "Hotel";
            }
            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{typeOfHoliday} - {price:f2}");
        }
    }
}
