using System;

namespace _02._Multiplication_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int num = 1; num <= 10; num++)
            {
                for (int num1 = 1; num1 <= 10; num1++)
                {
                    //int a = num * num1;
                    Console.WriteLine($"{num} * {num1} = {num * num1}");
                }
            }
        }
    }
}
