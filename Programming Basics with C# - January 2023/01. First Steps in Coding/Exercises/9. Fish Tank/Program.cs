using System;

namespace Fish_Tank
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double rate = double.Parse(Console.ReadLine())/100;
            double capacity = length * width * height;
            double capacityinLitters = capacity / 1000;
            double necessaryLitters = capacityinLitters * (1 - rate);
            Console.WriteLine(necessaryLitters);
        }
    }
}
