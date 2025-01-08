using System;

namespace _07._Water_Overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacityOfTank = 255; //255 liters
            int linesCount = int.Parse(Console.ReadLine());
            int sumOfLiters = 0;

            for (int i = 0; i < linesCount; i++)
            {
                int liters = int.Parse(Console.ReadLine());
                sumOfLiters += liters;

                if (sumOfLiters > capacityOfTank)
                {
                    sumOfLiters -= liters;
                    Console.WriteLine("Insufficient capacity!");
                }
            }

            Console.WriteLine(sumOfLiters);
        }
    }
}