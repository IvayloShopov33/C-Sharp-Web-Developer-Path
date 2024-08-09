using System;

namespace _08._Basketball_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double taxPerYear = double.Parse(Console.ReadLine());
            double shoes = taxPerYear - taxPerYear * 0.4;
            double kit = shoes - shoes * 0.2;
            double ball = kit * 0.25;
            double accessories = ball * 0.2;
            double sum = taxPerYear + shoes + kit + ball + accessories;
            Console.WriteLine(sum);
        }
    }
}
