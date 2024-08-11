using System;
using System.Linq;
namespace _7._Equal_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstArray = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] secondArray = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            bool isEqual = true;
            for (int i = 0; i < firstArray.Length; i++)
            {
                if (firstArray[i]!=secondArray[i])
                {
                    isEqual = false;
                    Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
                    break;
                }
            }
            if (isEqual)
            {
                Console.WriteLine($"Arrays are identical. Sum: {firstArray.Sum()}");
            }
        }
    }
}
