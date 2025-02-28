using System;

namespace _05._Multiplication_Sign
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());
            
            Negative(num1, num2, num3);
            Positive(num1, num2, num3);
            
            Zero(num1, num2, num3);
        }
        
        static void Negative(int num1, int num2, int num3)
        {
            if (num1 < 0 && num2 < 0 && num3 < 0)
            {
                Console.WriteLine("negative");
            }
            else if (num1 < 0 && num2 > 0 && num3 > 0)
            {
                Console.WriteLine("negative");
            }
            else if (num1 > 0 && num2 < 0 && num3 > 0)
            {
                Console.WriteLine("negative");
            }
            else if (num1 > 0 && num2 > 0 && num3 < 0)
            {
                Console.WriteLine("negative");
            }
        }
        
        static void Positive(int num1, int num2, int num3)
        {
            if (num1 > 0 && num2 > 0 && num3 > 0)
            {
                Console.WriteLine("positive");
            }
            else if (num1 < 0 && num2 > 0 && num3 < 0)
            {
                Console.WriteLine("positive");
            }
            else if (num1 > 0 && num2 < 0 && num3 < 0)
            {
                Console.WriteLine("positive");
            }
            else if (num1 < 0 && num2 < 0 && num3 > 0)
            {
                Console.WriteLine("positive");
            }
        }
        
        static void Zero(int num1, int num2, int num3)
        {
            if (num1 == 0)
            {
                Console.WriteLine("zero");
            }
            else if (num2 == 0)
            {
                Console.WriteLine("zero");
            }
            else if (num3 == 0)
            {
                Console.WriteLine("zero");
            }
        }
    }
}
