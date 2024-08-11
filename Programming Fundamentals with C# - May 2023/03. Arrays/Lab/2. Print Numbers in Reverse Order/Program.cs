using System;

namespace _2._Print_Numbers_in_Reverse_Order
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbersCount = int.Parse(Console.ReadLine());
            int[] Arr = new int[numbersCount];
            for (int i = 0; i < numbersCount; i++)
            {
                int number = int.Parse(Console.ReadLine());
                Arr[i] = number;
            }
            
            for (int l = Arr.Length - 1; l >= 0; l--)
            {
                Console.Write($"{Arr[l]} ");
            }
        }
    }
}
