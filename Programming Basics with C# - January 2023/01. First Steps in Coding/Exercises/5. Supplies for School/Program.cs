using System;

namespace _05._Supplies_for_School
{
    class Program
    {
        static void Main(string[] args)
        {
            int pens = int.Parse(Console.ReadLine());
            int markers = int.Parse(Console.ReadLine());
            int cleanLitters = int.Parse(Console.ReadLine());
            double rate= double.Parse(Console.ReadLine())/100;           
            double pensPrice = pens * 5.8;
            double markersPrice = markers * 7.2;
            double cleanLittersPrice = cleanLitters * 1.2;
            double sum = pensPrice + markersPrice + cleanLittersPrice;
            double allWithDiscount = sum - (sum * rate);
            Console.WriteLine(allWithDiscount);

        }
    }
}
