using System;

namespace _4_task
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double kilometers = double.Parse(Console.ReadLine());
            
            double sum = 0;
            double sum1 = 0;

            for (int i = 1; i <= n; i++)
            {
                int percent = int.Parse(Console.ReadLine());

                if (i == 1)
                {
                    sum = kilometers + ((double)percent / 100 * kilometers);
                    sum1 = sum + kilometers;
                }
                else
                {
                    sum = sum + ((double)percent / 100 * sum);
                    sum1 += sum;
                }  
            }

            if (sum1 >= 1000) 
                Console.WriteLine($"You've done a great job running {Math.Ceiling(sum1 - 1000)} more kilometers!");
            else
                Console.WriteLine($"Sorry Mrs. Ivanova, you need to run {Math.Ceiling(1000 - sum1)} more kilometers");
        }
    }
}
