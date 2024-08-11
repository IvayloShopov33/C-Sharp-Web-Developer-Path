using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace _1._Winning_Ticket
{
    class Program
    {
        static void Main(string[] args)
        {
            string array = Console.ReadLine();
            int maxLength = 0;

            for (int i = 0; i < array.Length; i++)
            {
                maxLength = Math.Max(maxLength, Palindrome(array, i, i));

            }

            for (int i = 0; i < array.Length - 1; i++)
            {
                maxLength = Math.Max(maxLength, Palindrome(array, i, i+1));
            }

            Console.WriteLine(maxLength);
        }

        private static int Palindrome(string array, int leftIndex, int rightIndex)
        {
            while (leftIndex >= 0 && rightIndex < array.Length && array[leftIndex] == array[rightIndex])
            {
                leftIndex--;
                rightIndex++;
            }

            return rightIndex - leftIndex - 1;
        }
    }
}