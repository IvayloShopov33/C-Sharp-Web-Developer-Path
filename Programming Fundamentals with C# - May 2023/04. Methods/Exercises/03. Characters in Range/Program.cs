using System;

namespace _3._Characters_in_Range
{
    class Program
    {
        static void Main(string[] args)
        {
            char a = char.Parse(Console.ReadLine());
            char b = char.Parse(Console.ReadLine());
            CharactersInRange(a, b);
        }
        static void CharactersInRange(char a, char b)
        {
            if (a>b)
            {
                int start = b + 1;
                int end = a;
                for (int i = start; i < end; i++)
                {
                    Console.Write($"{(char)i} ");
                }
            }
            else
            {
                for (int i = a + 1; i < b; i++)
                {
                    Console.Write($"{(char)i} ");
                }
            }
        }
    }
}
