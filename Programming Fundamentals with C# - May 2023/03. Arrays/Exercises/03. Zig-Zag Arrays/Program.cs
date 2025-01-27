using System;
using System.Linq;

namespace _3._Zig_Zag_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int linesCount = int.Parse(Console.ReadLine());
            int[] leftDigits = new int[linesCount];
            int[] rightDigits = new int[linesCount];
            
            for (int i = 0; i < linesCount; i++)
            {
                int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                if (i % 2 == 0)
                {
                    leftDigits[i] = array[0];
                    rightDigits[i] = array[1];
                }
                else
                {
                    leftDigits[i] = array[1];
                    rightDigits[i] = array[0];
                }
            }
            
            Console.WriteLine(String.Join(' ', leftDigits));
            Console.WriteLine(String.Join(' ', rightDigits));
        }
    }
}
