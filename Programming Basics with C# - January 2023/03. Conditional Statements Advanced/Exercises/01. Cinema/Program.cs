using System;

namespace _01._Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeProjection = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int colons = int.Parse(Console.ReadLine());
            double income = rows * colons;
            if (typeProjection=="Premiere")
            {
                income=income * 12;
            }
            else if (typeProjection=="Normal")
            {
                income = income * 7.5;
            }
            else if (typeProjection=="Discount")
            {
                income = income * 5;
            }
            Console.WriteLine($"{income:f2} leva");
        }
    }
}
