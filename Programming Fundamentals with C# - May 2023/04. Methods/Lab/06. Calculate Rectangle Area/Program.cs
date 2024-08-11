using System;

namespace _06._Calculate_Rectangle_Area
{
    class Program
    {
        static void Main(string[] args)
        {
            double widgth = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double area = GetRectangleArea(widgth, height);
            Console.WriteLine(area);
        }
        static double GetRectangleArea(double width, double height)
        {
            return width * height;
        }
    }
}
