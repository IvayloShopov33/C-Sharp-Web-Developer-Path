using System;
using System.Linq;

namespace _04._Print_and_sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int startNumber = int.Parse(Console.ReadLine());
            int endNumber = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = startNumber; i <= endNumber; i++)
            {
                Console.Write(i+" ");
                sum += i;
            }
            Console.WriteLine();
            Console.WriteLine($"Sum: {sum}");
            //second opportunity for solution
            //int start=int.Parse(Console.ReadLine());
            //int end= int.Parse(Console.ReadLine());
            //var sequence = Enumerable.Range(start, end - start + 1);
            //Console.WriteLine(string.Join(' ', sequence));
            //Console.WriteLine($"Sum: {sequence.Sum()}");
        }
    }
}
