using System;

namespace _8._Town_Info
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameOfTown = Console.ReadLine();
            long population = long.Parse(Console.ReadLine());
            long area=long.Parse(Console.ReadLine());
            Console.WriteLine($"Town {nameOfTown} has population of {population} and area {area} square km.");
        }
    }
}
