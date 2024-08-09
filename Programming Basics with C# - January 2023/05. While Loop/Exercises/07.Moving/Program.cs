using System;

namespace _07.Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            int volume = length * width * height;
            string input = Console.ReadLine();
            while(input!="Done")
            {
                int cartons = int.Parse(input);
                if (cartons<volume)
                {
                    volume -= cartons;
                    input = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine($"No more free space! You need {Math.Abs(volume-cartons)} Cubic meters more.");
                    break;
                }
            }
            if (input=="Done")
            {
                Console.WriteLine($"{volume} Cubic meters left.");
            }
        }
    }
}
