using System;

namespace Zoo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Animal gorilla = new Gorilla("Simba");
            Reptile snake = new Snake("Smok");
            Mammal bear = new Bear("Mecho");

            Console.WriteLine(gorilla.Name);
            Console.WriteLine(snake.Name);
            Console.WriteLine(bear.Name);
        }
    }
}