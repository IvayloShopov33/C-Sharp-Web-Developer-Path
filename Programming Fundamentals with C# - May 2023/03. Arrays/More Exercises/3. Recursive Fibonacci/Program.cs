using System;

namespace _3._Recursive_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arrayOfNumbers = new int[n];
            arrayOfNumbers[0] = 1;
            
            if (n <= 2)
            {
                Console.WriteLine(1);
            }
            else
            {
                int a = 0;
                arrayOfNumbers[1] = 1;
                
                for (int i = 2; i < n; i++)
                {
                    arrayOfNumbers[i] = arrayOfNumbers[i - 2] + arrayOfNumbers[i - 1];
                    a = arrayOfNumbers[i];
                }
                
                Console.WriteLine(a);
            }
        }
    }
}
