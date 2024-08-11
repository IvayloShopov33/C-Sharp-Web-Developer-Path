using System;

namespace _3._Longer_Line
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            double x3 = double.Parse(Console.ReadLine());
            double y3 = double.Parse(Console.ReadLine());
            double x4 = double.Parse(Console.ReadLine());
            double y4 = double.Parse(Console.ReadLine());

            PrintLongerLine(x1, y1, x2, y2, x3, y3, x4, y4);
        }
        static void PrintLongerLine(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4)
        {
            double distance1 = CalculateDistanceToCenter(x1, y1);
            double distance2 = CalculateDistanceToCenter(x2, y2);
            double distance3 = CalculateDistanceToCenter(x3, y3);
            double distance4 = CalculateDistanceToCenter(x4, y4);
            double length1 = CalculateLineLength(x1, y1, x2, y2);
            double length2 = CalculateLineLength(x3, y3, x4, y4);
            if (length1>=length2)
            {
                if (distance1<=distance2)
                {
                    Console.WriteLine($"({x1}, {y1})({x2}, {y2})");
                }
                else
                {
                    Console.WriteLine($"({x2}, {y2})({x1}, {y1})");
                }
            }
            else
            {
                if (distance3<=distance4)
                {
                    Console.WriteLine($"({x3}, {y3})({x4}, {y4})");
                }
                else
                {
                    Console.WriteLine($"({x4}, {y4})({x3}, {y3})");
                }
            }
        }
        static double CalculateDistanceToCenter(double x, double y)
        {
            double distance = Math.Sqrt(x * x + y * y);
            return distance;
        }
        static double CalculateLineLength(double x1, double y1, double x2, double y2)
        {
            double length = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            return length;
        }
    }
}
