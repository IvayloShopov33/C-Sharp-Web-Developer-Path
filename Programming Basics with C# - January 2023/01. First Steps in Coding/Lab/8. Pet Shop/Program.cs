using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp8
{
    class Program
    {
        static void Main(string[] args)
        {
            int dogs = int.Parse(Console.ReadLine());
            int cats = int.Parse(Console.ReadLine());
            double a = dogs * 2.5;
            int b = cats * 4;
            double c = a + b;
            Console.WriteLine($"{c} lv.");
        }
    }
}
