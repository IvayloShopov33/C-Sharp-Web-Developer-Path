using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string[] input = Console.ReadLine().Split();
            while (input[0]!="Finish")
            {
                int value = int.Parse(input[1]);
                if (input[0]=="Add")
                {
                    numbers.Add(value);
                }

                else if (input[0]=="Remove")
                {
                    if (numbers.Contains(value))
                    {
                        int indexOfTheValue = numbers.IndexOf(value);
                        numbers.RemoveAt(indexOfTheValue);
                    }
                }

                else if (input[0]=="Replace")
                {
                    if (numbers.Contains(value))
                    {
                        int indexOfTheValue = numbers.IndexOf(value);
                        int replacementValue = int.Parse(input[2]);
                        numbers.Insert(indexOfTheValue + 1, replacementValue);
                        numbers.RemoveAt(indexOfTheValue);
                    }
                }

                else if (input[0]=="Collapse")
                {
                    numbers.RemoveAll(x => x < value);
                }

                input = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
