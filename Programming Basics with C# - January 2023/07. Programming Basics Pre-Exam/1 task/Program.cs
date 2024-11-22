using System;

namespace _1_task
{
    class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            int nights = int.Parse(Console.ReadLine());
            int transportCards = int.Parse(Console.ReadLine());
            int museumTickets = int.Parse(Console.ReadLine());

            double nightsSum = nights * 20;
            double transportCardsSum = transportCards * 1.6;
            double museumTicketsSum = museumTickets * 6;
            double sumForOne = nightsSum + transportCardsSum + museumTicketsSum;
            double sumForAll = sumForOne * people;
            double sum = sumForAll + 0.25 * sumForAll;

            Console.WriteLine($"{sum:f2}");
        }
    }
}
