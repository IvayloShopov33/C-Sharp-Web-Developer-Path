using System;

namespace _01._Black_Flag
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysOfPirating = int.Parse(Console.ReadLine());
            double plunderForOneDay = double.Parse(Console.ReadLine());
            double expectedPlunder = double.Parse(Console.ReadLine());
            int days = 0;
            double allPlunder = 0;
            double plunderForOneDayExtra = 0;
            while (days != daysOfPirating)
            {
                days++;
                if (days % 3 == 0)
                {
                    plunderForOneDayExtra = plunderForOneDay * 0.5;
                    allPlunder += plunderForOneDay + plunderForOneDayExtra;
                }

                else
                {
                    allPlunder += plunderForOneDay;
                }

                if (days % 5 == 0)
                {
                    allPlunder -= allPlunder * 0.3;
                }
            }

            if (allPlunder >= expectedPlunder)
            {
                Console.WriteLine($"Ahoy! {allPlunder:f2} plunder gained.");
            }

            else
            {
                double percent = allPlunder / expectedPlunder * 100;
                Console.WriteLine($"Collected only {percent:f2}% of the plunder.");
            }
        }
    }
}
