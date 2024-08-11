using System;

namespace _8._Math_Power
{
    class Program
    {
        static void Main(string[] args)
        {
            double baseNumber = double.Parse(Console.ReadLine());
            int powerNumber = int.Parse(Console.ReadLine());
            double finalNumber = MathPower(baseNumber, powerNumber);
            Console.WriteLine(finalNumber);
        }
        static double MathPower(double baseNumber, int powerNumber)
        {
            double finalNumber =  Math.Pow(baseNumber, powerNumber);
            return finalNumber;
        }
    }
}
