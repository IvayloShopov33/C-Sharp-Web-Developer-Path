using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._List_Manipulation_Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string[] input = Console.ReadLine().Split();
            while (input[0] != "end")
            {
                if (input[0] == "Add")
                {
                    numbers = Add(input, numbers);
                }
                else if (input[0] == "Remove")
                {
                    numbers = Remove(input, numbers);
                }
                else if (input[0] == "RemoveAt")
                {
                    numbers = RemoveAt(input, numbers);
                }
                else if (input[0] == "Insert")
                {
                    numbers = Insert(input, numbers);
                }

                input = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join(' ', numbers));
        }

        static List<int> Add(string[] input, List<int> num)
        {
            num.Add(int.Parse(input[1]));
            return num;
        }

        static List<int> Remove(string[] input, List<int> numbers)
        {
            numbers.Remove(int.Parse(input[1]));
            return numbers;
        }

        static List<int> RemoveAt(string[] input, List<int> numbers)
        {
            numbers.RemoveAt(int.Parse(input[1]));
            return numbers;
        }

        static List<int> Insert(string[] input, List<int> numbers)
        {
            int number = int.Parse(input[1]);
            int index = int.Parse(input[2]);
            numbers.Insert(index, number);
            return numbers;
        }
    }
}
