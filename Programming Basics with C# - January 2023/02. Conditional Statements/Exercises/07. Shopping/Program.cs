using System;

namespace _07._Shopping
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int gpuQuantity = int.Parse(Console.ReadLine());
            int cpuQuantity = int.Parse(Console.ReadLine());
            int ramQuantity = int.Parse(Console.ReadLine());
            int gpuSum = 250 * gpuQuantity;
            double cpuPrice = gpuSum * 0.35;
            double cpuSum = cpuPrice * cpuQuantity;
            double ramPrice = gpuSum * 0.1;
            double ramSum = ramPrice * ramQuantity;
            double sumAll = gpuSum + cpuSum + ramSum;
            if (gpuQuantity > cpuQuantity)
            {
                sumAll = sumAll - sumAll * 0.15;
            }
            if (budget>=sumAll)
            {
                Console.WriteLine($"You have {budget-sumAll:f2} leva left!");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {sumAll-budget:f2} leva more!");
            }
        }
    }
}
