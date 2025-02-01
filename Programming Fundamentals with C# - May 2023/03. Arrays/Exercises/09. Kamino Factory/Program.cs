using System;
using System.Linq;

namespace _09._Kamino_Factory
{
    internal class Program
    {
        static void Main()
        {
            int index = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            int[] bestDNA = new int[index];
            int bestLength = 0;
            int bestPosition = 0;
            int bestSum = 0;
            int curentDNA = 0, dnaIndex = 1;

            while (input != "Clone them!")
            {
                int position = 0;
                int count = 0, curentLength = 0;
                int curentSum = 0;
                curentDNA++;

                int[] array = input
                    .Split(separator: "!", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] != 1)
                    {
                        count = 0;
                        continue;
                    }

                    count++;

                    if (count > curentLength)
                    {
                        curentLength = count;
                        position = i;
                    }
                }

                position = position - curentLength + 1;
                curentSum = array.Sum();

                if (bestLength < curentLength ||
                    bestLength == curentLength && bestPosition > position ||
                    bestLength == curentLength && bestPosition == position && curentSum > bestSum)
                {
                    bestSum = curentSum;
                    bestPosition = position;
                    bestLength = curentLength;
                    bestDNA = array;
                    dnaIndex = curentDNA;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Best DNA sample {dnaIndex} with sum: {bestSum}.");
            Console.WriteLine(string.Join(" ", bestDNA));
        }
    }
}
