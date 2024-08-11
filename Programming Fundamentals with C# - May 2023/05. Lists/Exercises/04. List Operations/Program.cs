using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._List_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string[] input = Console.ReadLine().Split();
            while (input[0] != "End")
            {
                if (input[0] == "Add")
                {
                    numbers = Add(input[1], numbers);
                }

                else if (input[0] == "Insert")
                {
                    int index = int.Parse(input[2]);
                    if (index < 0 || index >= numbers.Count)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        numbers = Insert(input[1], index, numbers);
                    }
                }

                else if (input[0] == "Remove")
                {
                    int index = int.Parse(input[1]);
                    if (index < 0 || index >= numbers.Count)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        numbers = Remove(index, numbers);
                    }
                }

                else if (input[0] == "Shift")
                {
                    if (input[1] == "left")
                    {
                        numbers = ShiftLeft(input[2], numbers);
                    }
                    else if (input[1] == "right")
                    {
                        numbers = ShiftRight(input[2], numbers);
                    }
                }

                input = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join(' ', numbers));
        }

        private static List<int> Add(string v, List<int> numbers)
        {
            int number = int.Parse(v);
            numbers.Add(number);
            return numbers;
        }

        private static List<int> Insert(string v1, int index, List<int> numbers)
        {
            int number = int.Parse(v1);
            numbers.Insert(index, number);
            return numbers;
        }

        private static List<int> Remove(int index, List<int> numbers)
        {
            numbers.RemoveAt(index);
            return numbers;
        }

        private static List<int> ShiftLeft(string v, List<int> numbers)
        {
            int count = int.Parse(v);
            for (int i = 0; i < count; i++)
            {
                int temp = numbers[0];
                numbers.RemoveAt(0);
                numbers.Add(temp);
            }

            return numbers;
        }

        private static List<int> ShiftRight(string v, List<int> numbers)
        {
            int count = int.Parse(v);
            for (int i = 0; i < count; i++)
            {
                int temp = numbers[numbers.Count - 1];
                numbers.RemoveAt(numbers.Count - 1);
                numbers.Insert(0, temp);
            }

            return numbers;
        }
    }
}
