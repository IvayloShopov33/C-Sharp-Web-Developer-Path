using System;

namespace _09._Sum_of_Odd_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = 1; i <= n; i++)
            {
                int m = i + i - 1;
                Console.WriteLine(m);
                sum += m;
            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
