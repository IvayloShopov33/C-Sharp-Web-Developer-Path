using System;

namespace _05._Travelling
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination;
            double budget;
            string input = Console.ReadLine();
                       
            while (input != "End")
            {
                destination = input;
                budget = double.Parse(Console.ReadLine());
                
                while (budget > 0)
                {
                    double money = double.Parse(Console.ReadLine());
                    budget -= money;
                }
                
                Console.WriteLine($"Going to {destination}!");
                input = Console.ReadLine();
            }
        }
    }
}
