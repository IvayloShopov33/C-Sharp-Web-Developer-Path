using System;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            //inches to centimeters
            double i = double.Parse(Console.ReadLine());
            double c = i * 2.54;
            
            Console.WriteLine(c);
        }
    }
}
