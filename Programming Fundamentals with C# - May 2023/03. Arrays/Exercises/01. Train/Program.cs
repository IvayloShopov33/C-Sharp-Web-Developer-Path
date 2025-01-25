using System;
using System.Linq;

namespace _1._Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int wagonsCount = int.Parse(Console.ReadLine());
            int[] wagons = new int[wagonsCount];
            
            for (int i = 0; i < wagonsCount; i++)
            {
                int people = int.Parse(Console.ReadLine());
                wagons[i] = people;
            }
            
            Console.WriteLine(String.Join(' ', wagons));
            Console.WriteLine(wagons.Sum());
        }
    }
}
