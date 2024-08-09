using System;

namespace _01._Excellent_Result
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            if (a>=5.5 && a<=6)
            {
                Console.WriteLine("Excellent!");
            }
        }
    }
}
