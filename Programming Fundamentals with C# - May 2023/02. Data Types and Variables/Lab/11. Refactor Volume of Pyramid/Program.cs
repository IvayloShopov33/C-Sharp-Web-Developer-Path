using System;

namespace _11._Refactor_Volume_of_Pyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            Console.Write("Length: ");
            Console.Write("Width: ");
            Console.Write("Height: ");
             double volume = (length * width * height) / 3;
            Console.Write($"Pyramid Volume: {volume:f2}");
        }
    }
}
