using System;

namespace _01._The_Biscuit_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            int biscuitsCount = int.Parse(Console.ReadLine());
            int workersCount = int.Parse(Console.ReadLine());
            int enemiesbiscuitsCount = int.Parse(Console.ReadLine());
            int allbiscuits = 0;
            int days = 0;
            int biscuitsPerDay = 0;
            while (days<30)
            {
                days++;
                biscuitsPerDay = biscuitsCount * workersCount;
                if (days%3==0)
                {
                    double production = 0.75 * biscuitsPerDay;
                    biscuitsPerDay = (int)Math.Floor(production);
                }
                allbiscuits += biscuitsPerDay;
            }

            int difference = Math.Abs(allbiscuits - enemiesbiscuitsCount);
            double percent = difference*1.0 / enemiesbiscuitsCount * 100;
            Console.WriteLine($"You have produced {allbiscuits} biscuits for the past month.");
            if (allbiscuits>enemiesbiscuitsCount)
            {
                Console.WriteLine($"You produce {percent:f2} percent more biscuits.");
            }
            else
            {
                Console.WriteLine($"You produce {percent:f2} percent less biscuits.");
            }
        }
    }
}
