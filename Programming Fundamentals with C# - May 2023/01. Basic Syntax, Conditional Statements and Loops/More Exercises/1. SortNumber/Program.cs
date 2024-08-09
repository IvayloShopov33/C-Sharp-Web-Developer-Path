using System;

namespace SortNumber__exception_
{
    class Program
    {
        static void Main(string[] args)
        {
            double num1 = double.Parse(Console.ReadLine());
            double num2= double.Parse(Console.ReadLine());
            double num3= double.Parse(Console.ReadLine());
            double[] Arr = { num1, num2, num3 };
            Array.Sort(Arr);
            Array.Reverse(Arr);
            for (int i = 0; i < Arr.Length; i++)
            {
                Console.WriteLine(Arr[i]);
            }
        }
    }
}
