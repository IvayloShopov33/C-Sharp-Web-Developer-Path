using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp9
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = a * 7.61;
            double c = b * 0.18;
            double d = b - c;
            Console.WriteLine($"The final price is: {d} lv.");
            Console.WriteLine($"The discount is: {c} lv.");
        }
    }
}
