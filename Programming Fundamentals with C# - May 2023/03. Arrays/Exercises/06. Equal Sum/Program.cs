using System;
using System.Linq;

namespace _06._Equal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            bool areEqual = false;
            
            for (int i = 0; i < numbers.Length; i++)
            {
                int number = numbers[i];
                int sumBeforeDigit = 0;
                int sumAfterDigit = 0;
                
                for (int j = 0; j < i; j++)
                {
                    sumBeforeDigit += numbers[j];
                }
                
                for (int k = i + 1; k < numbers.Length; k++)
                {
                    sumAfterDigit += numbers[k];
                }
                
                if (sumBeforeDigit == sumAfterDigit)
                {
                    areEqual = true;
                    Console.WriteLine(i); //the index of the element which satisfies the condition
                    
                    break;
                }
            }
            
            if (!areEqual)
            {
                Console.WriteLine("no");
            }
        }
    }
}
