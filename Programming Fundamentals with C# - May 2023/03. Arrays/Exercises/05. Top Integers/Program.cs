using System;
using System.Linq;

namespace _5._Top_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != array.Max())
                {
                    for (int j = i; j < array.Length; j++)
                    {
                        if (array[i] < array[j])
                        {
                            break;
                        }
                        
                        if (array[i] > array[j] && j == array.Length - 1)
                        {
                            Console.Write($"{array[i]} ");
                        }
                    }
                }
                else
                {
                    Console.Write($"{array[i]} ");
                }
            }
            
            if (array[array.Length - 1] != array.Max())
            {
                Console.Write(array[array.Length - 1]);
            }
        }
    }
}
