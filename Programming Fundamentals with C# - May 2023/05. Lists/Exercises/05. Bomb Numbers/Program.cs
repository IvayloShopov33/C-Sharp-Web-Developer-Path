using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string[] commands = Console.ReadLine().Split();

            while (numbers.Contains(int.Parse(commands[0])))
            {
                int bomb = int.Parse(commands[0]);
                int power = int.Parse(commands[1]);
                int index = numbers.IndexOf(bomb);

                if (numbers.Count > index + power)
                {
                    for (int i = index + 1; i < index + power + 1; i++)
                    {
                        numbers.RemoveAt(index + 1);
                    }
                }
                else
                {
                    for (int i = index + 1; i < numbers.Count; i++)
                    {
                        numbers.RemoveAt(index + 1);
                    }
                }

                if (index - power >= 0)
                {
                    for (int i = index; i >= index - power; i--)
                    {
                        numbers.RemoveAt(i);
                    }
                }
                else
                {
                    for (int i = index; i >= 0; i--)
                    {
                        numbers.RemoveAt(i);
                    }
                }
            }
            Console.WriteLine(numbers.Sum());
        }
    }
}
