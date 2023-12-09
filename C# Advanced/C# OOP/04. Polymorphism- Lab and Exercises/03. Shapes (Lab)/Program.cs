using Shapes.Models;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Shape circle = new Circle(5);
            Shape rectangle = new Rectangle(6, 7);

            Console.WriteLine(circle.Draw());
            Console.WriteLine($"Perimeter: {circle.CalculatePerimeter()}, Area: {circle.CalculateArea()}");

            Console.WriteLine(rectangle.Draw());
            Console.WriteLine($"Perimeter: {rectangle.CalculatePerimeter()}, Area: {rectangle.CalculateArea()}");
        }
    }
}