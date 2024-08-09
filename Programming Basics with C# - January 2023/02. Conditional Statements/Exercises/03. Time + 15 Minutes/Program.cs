using System;

namespace _03._Time___15_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int min = int.Parse(Console.ReadLine());
            min = min + hours * 60;
            min += 15;
            hours = min / 60;
            min = min % 60;
            if (hours==24)
            {
                hours = 0;
            }
            Console.WriteLine($"{hours}:{min:D2}");
        }
    }
}
