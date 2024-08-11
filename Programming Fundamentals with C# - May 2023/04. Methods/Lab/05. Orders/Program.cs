using System;

namespace _5._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());
            if (product == "coffee")
                Coffee(quantity);
            else if (product == "water")
                Water(quantity);
            else if (product == "coke")
                Coke(quantity);
            else if (product == "snacks")
                Snacks(quantity);
        }
        static void Coffee(int quantity)
        {
            double result = quantity * 1.5;
            Console.WriteLine($"{result:f2}");
        }
        static void Water(int quantity)
        {
            double result = quantity * 1.00;
            Console.WriteLine($"{result:f2}");
        }
        static void Coke(int quantity)
        {
            double result = quantity * 1.40;
            Console.WriteLine($"{result:f2}");
        }
        static void Snacks(int quantity)
        {
            double result = quantity * 2.00;
            Console.WriteLine($"{result:f2}");
        }
    }
}
