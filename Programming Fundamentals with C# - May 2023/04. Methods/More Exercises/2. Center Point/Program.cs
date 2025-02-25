using System;

namespace _2._Center_Point
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            
            CloserToCenterPoint(x1, y1, x2, y2);
        }
        
        static void CloserToCenterPoint(double x1, double y1, double x2, double y2)
        {
            double distance1 = CalculateDistanceToCenter(x1, y1);
            double distance2 = CalculateDistanceToCenter(x2, y2);
            
            if (distance1 <= distance2)
            {
                Console.WriteLine($"({x1}, {y1})");
            }
            else
            {
                Console.WriteLine($"({x2}, {y2})");
            }
        }
        
        static double CalculateDistanceToCenter(double x, double y)
        {
            double distance = Math.Sqrt(x * x + y * y);
            
            return distance;
        }
    }
}
