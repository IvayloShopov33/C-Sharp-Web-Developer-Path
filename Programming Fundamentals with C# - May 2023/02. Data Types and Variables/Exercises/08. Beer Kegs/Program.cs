using System;

namespace _08._Beer_Kegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int beerKegsCount = int.Parse(Console.ReadLine());
            double biggestVolume = double.MinValue;
            string biggestModel = string.Empty;

            for (int i = 0; i < beerKegsCount; i++)
            {
                string modelOfKeg = Console.ReadLine();
                float radius = float.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());
                double volume = Math.PI * Math.Pow(radius, 2) * height;

                if (biggestVolume < volume)
                {
                    biggestVolume = volume;
                    biggestModel = modelOfKeg;
                }
            }

            Console.WriteLine(biggestModel);
        }
    }
}