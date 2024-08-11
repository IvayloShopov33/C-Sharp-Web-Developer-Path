using System;
using System.Linq;

namespace _02._Array_Modifier
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string[] input = Console.ReadLine().Split();
            while (input[0]!="end")
            {
                if (input[0]=="swap")
                {
                    int index1 = int.Parse(input[1]);
                    int index2 = int.Parse(input[2]);
                    int temp = numbers[index1];
                    numbers[index1] = numbers[index2];
                    numbers[index2] = temp;
                }

                else if (input[0]=="multiply")
                {
                    int index1 = int.Parse(input[1]);
                    int index2 = int.Parse(input[2]);
                    numbers[index1] *= numbers[index2];
                }

                else if (input.Length==1)
                {
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        numbers[i]--;
                    }
                }

                input = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
