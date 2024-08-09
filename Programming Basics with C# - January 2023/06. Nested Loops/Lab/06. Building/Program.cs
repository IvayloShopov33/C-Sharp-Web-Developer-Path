using System;

namespace _06._Building
{
    class Program
    {
        static void Main(string[] args)
        {
            int floors = int.Parse(Console.ReadLine());
            int rooms = int.Parse(Console.ReadLine());
           for(int floor=floors;floor>=1;floor--)
            {
                for (int room = 0; room < rooms; room++)
                {
                    if (floor==floors)
                    {
                        Console.Write($"L{floor}{room} ");
                    }
                    else
                    {
                        if (floor%2==1)
                        {
                            Console.Write($"A{floor}{room} ");
                        }
                        else
                        {
                            Console.Write($"O{floor}{room} ");
                        }
                    }
                   
                }
                Console.WriteLine();
            }
        }
    }
}
