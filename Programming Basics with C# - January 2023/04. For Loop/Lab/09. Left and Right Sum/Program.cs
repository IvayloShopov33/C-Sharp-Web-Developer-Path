using System;

namespace _09._Left_and_Right_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            int sum1 = 0;
            
            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                sum += number;
            }
            
            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                sum1 += number;
            }
            
            if (sum == sum1)
            {
                Console.WriteLine($"Yes, sum = {sum}");
            }
            else
            {
                Console.WriteLine($"No, diff = {Math.Abs(sum-sum1)}");
            }
        }
    }
}
