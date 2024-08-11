using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._List_Manipulation_Advanced
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string[] input = Console.ReadLine().Split();
            List<int> numbers1 = numbers.ToList();
            int[] num = numbers1.ToArray();
            bool flag = false;
            while (input[0] != "end")
            {
                if (input[0] == "Add")
                {
                    numbers1 = Add(input, numbers1);
                    flag = true;
                }

                else if (input[0] == "Remove")
                {
                     numbers1 = Remove(input, numbers1);
                    flag = true;
                }

                else if (input[0] == "RemoveAt")
                {
                     numbers1 = RemoveAt(input, numbers1);
                    flag = true;
                }

                else if (input[0] == "Insert")
                {
                     numbers1 = Insert(input, numbers1);
                    flag = true;
                }

                else if (input[0] == "Contains")
                {
                    Contains(input, numbers1);
                }

                else if (input[0] == "PrintEven")
                {
                    
                     numbers1 = PrintEven(num);
                    Console.WriteLine(string.Join(' ', numbers1));
                }

                else if (input[0] == "PrintOdd")
                {
                     numbers1 = PrintOdd(num);
                    Console.WriteLine(string.Join(' ', numbers1));
                }

                else if (input[0] == "GetSum")
                {
                    GetSum(num);
                }

                else if (input[0] == "Filter")
                {
                     numbers1 = Filter(input, num);
                    Console.WriteLine(String.Join(' ', numbers1));
                }

                input = Console.ReadLine().Split();
            }

            if (flag)
            {
                Console.WriteLine(string.Join(' ', numbers1)) ;
            }
        }

        static List<int> Add(string[] input, List<int> num)
        {
            List<int> numbers2 = num.ToList();

            numbers2.Add(int.Parse(input[1]));
            return numbers2;
        }

        static List<int> Remove(string[] input, List<int> numbers)
        {
            List<int> numbers2 = numbers.ToList();

            numbers2.Remove(int.Parse(input[1]));
            return numbers2;
        }

        static List<int> RemoveAt(string[] input, List<int> numbers)
        {
            List<int> numbers2 = numbers.ToList();

            numbers2.RemoveAt(int.Parse(input[1]));
            return numbers2;
        }

        static List<int> Insert(string[] input, List<int> numbers)
        {
            List<int> numbers2 = numbers.ToList();

            int number = int.Parse(input[1]);
            int index = int.Parse(input[2]);
            numbers2.Insert(index, number);
            return numbers2;
        }

        static void Contains(string[] input, List<int> numbers)
        {
            int number = int.Parse(input[1]);
            List<int> numbers2 = numbers.ToList();

            if (numbers2.Contains(number))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No such number");
            }
        }

        static List<int> PrintEven(int[] numbers)
        {
            List<int> numbers2 = numbers.ToList();

            numbers2.RemoveAll(x => x % 2 == 1);
            return numbers2;
        }

        static List<int> PrintOdd(int[] numbers)
        {
            List<int> numbers2 = numbers.ToList();

            numbers2.RemoveAll(y => y % 2 == 0);
            return numbers2;
        }

        static void GetSum(int[] numbers)
        {
            Console.WriteLine(numbers.Sum());
        }

        static List<int> Filter(string[] input, int[] numbers)
        {
            string condition = input[1];
            int number = int.Parse(input[2]);
            List<int> numbers2 = numbers.ToList();
            if (condition == "<")
            {
                numbers2.RemoveAll(x => x >= number);
            }
            else if (condition == ">")
            {
                numbers2.RemoveAll(x => x <= number);
            }
            else if (condition == ">=")
            {
                numbers2.RemoveAll(x => x < number);
            }
            else if (condition == "<=")
            {
                numbers2.RemoveAll(x => x > number);
            }
            return numbers2;
        }
    }
}
