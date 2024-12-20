using System;

namespace _2.Last_digit_name_exc
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int digit = n % 10;
            
            if (digit == 0)
                Console.WriteLine("zero");
            else if (digit == 1)
                Console.WriteLine("one");
            else if (digit == 2)
                Console.WriteLine("two");
            else if (digit == 3)
                Console.WriteLine("three");
            else if (digit == 4)
                Console.WriteLine("four");
            else if (digit == 5)
                Console.WriteLine("five");
            else if (digit == 6)
                Console.WriteLine("six");
            else if (digit == 7)
                Console.WriteLine("seven");
            else if (digit == 8)
                Console.WriteLine("eight");
            else
                Console.WriteLine("nine");
        }
    }
}
