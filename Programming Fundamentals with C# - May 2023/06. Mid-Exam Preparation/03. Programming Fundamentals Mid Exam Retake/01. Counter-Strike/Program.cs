using System;

namespace _01._Counter_Strike
{
    class Program
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            int battlesWon = 0;
            bool lost = false;
            while (input!="End of battle")
            {
                int distance = int.Parse(input);
                if (energy<distance)
                {                 
                    Console.WriteLine($"Not enough energy! Game ends with {battlesWon} won battles and {energy} energy");
                    lost = true;
                    break;
                }

                energy -= distance;
                battlesWon++;

                if (battlesWon%3==0)
                {
                    energy += battlesWon;
                }

               input=Console.ReadLine();
            }

            if (!lost)
            {
                Console.WriteLine($"Won battles: {battlesWon}. Energy left: {energy}");
            }
        }
    }
}
