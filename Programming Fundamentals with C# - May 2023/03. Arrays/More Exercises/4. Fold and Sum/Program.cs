using System;
using System.Linq;

namespace _4._Fold_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayOfNumbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int k = arrayOfNumbers.Length / 4;
            int[] firstOfFirstRow = new int[k];
            int[] lastOfFirstRow = new int[k];
            int[] middleRow = new int[2 * k];
            for (int i = 0; i < k; i++)
            {
                firstOfFirstRow[i] = arrayOfNumbers[i];
                lastOfFirstRow[i] = arrayOfNumbers[arrayOfNumbers.Length - k + i];
            }
            Array.Reverse(firstOfFirstRow);
            Array.Reverse(lastOfFirstRow);
            for (int i = 0; i < 2*k; i++)
            {
                middleRow[i] = arrayOfNumbers[arrayOfNumbers.Length + i - (3 * k)];
            }
            int[] halfRow = new int[k]; 
            for (int i = 0; i < halfRow.Length; i++)
            {
                halfRow[i] = firstOfFirstRow[i] + middleRow[i];
                
            }
            Console.Write($"{String.Join(' ', halfRow)} ");
            int[] halfRowTwo = new int[k];
            for (int i = 0; i < halfRow.Length; i++)
            {
                halfRowTwo[i] = lastOfFirstRow[i] + middleRow[i + k];
            }
            Console.Write($"{String.Join(' ', halfRowTwo)} ");
        }
    }
}
