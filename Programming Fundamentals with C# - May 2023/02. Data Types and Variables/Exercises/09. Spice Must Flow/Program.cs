using System;

namespace _09._Spice_Must_Flow
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingYield = int.Parse(Console.ReadLine());
            int days = 0;
            int sumOfWorkersConsumption = 0;

            while (startingYield >= 100)
            {
                int workersConsumption = startingYield - 26;
                sumOfWorkersConsumption += workersConsumption;

                startingYield -= 10;
                days++;
            }

            if (sumOfWorkersConsumption >= 26)
            {
                sumOfWorkersConsumption -= 26;
            }

            Console.WriteLine(days);
            Console.WriteLine(sumOfWorkersConsumption);
        }
    }
}