using System;

namespace _03._Sum_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int initialSum = int.Parse(Console.ReadLine());
            int sum = 0;
            
            while (sum < initialSum)
            {
                int num = int.Parse(Console.ReadLine());
                sum += num;
            }
            
            Console.WriteLine(sum);
        }
    }
}
