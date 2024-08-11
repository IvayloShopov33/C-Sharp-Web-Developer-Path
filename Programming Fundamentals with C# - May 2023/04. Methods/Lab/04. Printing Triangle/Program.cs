using System;

namespace _4._Printing_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            FirstSide(number);
            SecondSide(number);
        }
        static void FirstSide(int number)
        {
            for (int i = 1; i <= number; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write(j +" ");
                }
                Console.WriteLine();
            }
        }
        static void SecondSide(int number) 
        {
            int k = number - 1;
            for (int i = k; i >= 1; i--)
            {
                for (int j = 1; j <= i ; j++)
                {
                    Console.Write(j+" ");
                }
                Console.WriteLine();
            }
        }
    }
}
