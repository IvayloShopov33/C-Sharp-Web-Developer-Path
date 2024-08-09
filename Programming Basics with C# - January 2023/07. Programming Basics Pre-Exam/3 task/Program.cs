using System;

namespace _3_task
{
    class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            double sum = 0;

            if (people <= 5)
            {
                if (season == "spring")
                    sum = people * 50;
                else if (season == "summer")
                {
                    sum = people * 48.5;
                    sum -= sum * 0.15;
                }
                else if (season == "autumn")
                    sum = people * 60;
                else if (season == "winter")
                {
                    sum = people * 86;
                    sum += sum * 0.08;
                }
            }
            else
            {
                if (season == "spring")
                    sum = people * 48;
                else if (season == "summer")
                {
                    sum = people * 45;
                    sum -= sum * 0.15;
                }
                else if (season == "autumn")
                    sum = people * 49.5;
                else if (season == "winter")
                {
                    sum = people * 85;
                    sum += sum * 0.08;
                }
            }

            Console.WriteLine($"{sum:f2} leva.");
        }
    }
}
