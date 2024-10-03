using System;

namespace _06._Operations_Between_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            char operation = char.Parse(Console.ReadLine());
            
            if (operation == '+' || operation == '-' || operation == '*')
            {
                int result;
                
                if (operation == '+')
                {
                    result = num1 + num2;
                }
                else if (operation == '-')
                {
                    result = num1 - num2;
                }
                else
                {
                    result = num1 * num2;
                }
                
                string evenOrOdd = string.Empty;
                
                if (result % 2 == 0)
                {
                    evenOrOdd = "even";
                }
                else
                {
                    evenOrOdd = "odd";
                }
                
                Console.WriteLine($"{num1} {operation} {num2} = {result} - {evenOrOdd}");
            }
            else // operation=='/' || operation=='%'
            {
                if (num2 == 0)
                {
                    Console.WriteLine($"Cannot divide {num1} by zero");
                }
                else if (operation == '/')
                {
                    double result = (double)num1 / num2;
                    Console.WriteLine($"{num1} / {num2} = {result:f2}");
                }
                 else if (operation == '%')
                {
                    int result = num1 % num2;
                    Console.WriteLine($"{num1} % {num2} = {result}");
                }
            }
        }
    }
}
