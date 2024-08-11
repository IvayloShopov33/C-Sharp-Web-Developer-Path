using System;
using System.Linq;

namespace _7._Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] seguenceOfNumbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int maxSequenceOfEqualElements = 0;
             int currentSequenceOfEqualElements = 1;
            int number = 0;
            for (int i = 0; i < seguenceOfNumbers.Length; i++)
            {
                if (i != seguenceOfNumbers.Length - 1)
                {
                    if (seguenceOfNumbers[i] == seguenceOfNumbers[i + 1])
                    {
                        currentSequenceOfEqualElements++;
                    }
                    else
                    {
                        currentSequenceOfEqualElements = 1;
                    }
                }
                if (maxSequenceOfEqualElements<currentSequenceOfEqualElements)
                {
                    maxSequenceOfEqualElements = currentSequenceOfEqualElements;
                    number = seguenceOfNumbers[i];
                }
            }
            for (int i = 0; i < maxSequenceOfEqualElements; i++)
            {
                Console.Write($"{number} ");
            }
        }
    }
}
