using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Change_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string[] input = Console.ReadLine().Split(' ');
            while (input[0] != "end")
            {
                if (input[0] == "Delete")
                {
                    numbers = Delete(input[1], numbers);
                }

                else if (input[0]=="Insert")
                {
                    numbers = Insert(input[1], input[2], numbers);
                }

                input = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join(' ', numbers));
        }

        private static List<int> Delete(string v, List<int> numbers)
        {
            int element = int.Parse(v);
            numbers.RemoveAll(x => x == element);
            return numbers;
        }

        private static List<int> Insert(string v1, string v2, List<int> numbers)
        {
            int element = int.Parse(v1);
            int position = int.Parse(v2);
            numbers.Insert(position, element);
            return numbers;
        }
    }
}
