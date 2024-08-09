using System;

namespace _10._Multiplication_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            for (int i = 1; i < 11; i++)
            {
                int result = number * i;
                Console.WriteLine($"{number} X {i} = {result}");
            }
        }
    }
}
