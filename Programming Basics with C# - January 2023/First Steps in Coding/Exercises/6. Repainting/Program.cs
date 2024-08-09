using System;

namespace _06._Repainting
{
    class Program
    {
        static void Main(string[] args)
        {
            int nylon = int.Parse(Console.ReadLine())+2;
            double paint = int.Parse(Console.ReadLine());
            paint = paint + paint * 0.1;   
            int thinner = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());
            double nylonPrice = nylon * 1.5;
            double paintPrice = paint * 14.5;
            double thinnerPrice = thinner * 5;
            double sum = nylonPrice + paintPrice + thinnerPrice + 0.4;
            double priceM = sum * 0.3;
            double allPrice = sum + priceM * hours;
            Console.WriteLine(allPrice);
            
        }
    }
}
