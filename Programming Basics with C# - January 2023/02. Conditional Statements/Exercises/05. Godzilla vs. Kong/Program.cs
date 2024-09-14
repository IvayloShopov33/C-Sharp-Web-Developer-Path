using System;

namespace _05._Godzilla_vs._Kong
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int extras = int.Parse(Console.ReadLine());
            double outfitExtraPrice = double.Parse(Console.ReadLine());

            double decorPrice = budget * 0.1;
            double outfitPrice = extras * outfitExtraPrice;

            if (extras > 150)
            {
                outfitPrice -= outfitPrice * 0.1;
            }

            double sum = decorPrice + outfitPrice;

            if (sum <= budget)
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {budget-sum:f2} leva left.");
            }
            else
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {sum-budget:f2} leva more.");
            }
        }
    }
}