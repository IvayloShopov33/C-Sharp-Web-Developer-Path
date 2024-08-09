using System;

namespace _07._Area_of_Figures
{
    class Program
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();
            double area = 0;
            if (figure == "square")
            {
                double a = double.Parse(Console.ReadLine());
                area = a * a;
            }
            else if (figure == "rectangle")
            {
                double b = double.Parse(Console.ReadLine());
                double c = double.Parse(Console.ReadLine());
                 area = b * c;
            }
            else if (figure == "circle")
            {
                double radius = double.Parse(Console.ReadLine());
                 area = Math.PI * radius * radius;
            }
            else if(figure=="triangle")
            {
                double side = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());
                 area = side * height / 2;
            }
            Console.WriteLine($"{area:f3}");
        }
    }
}
