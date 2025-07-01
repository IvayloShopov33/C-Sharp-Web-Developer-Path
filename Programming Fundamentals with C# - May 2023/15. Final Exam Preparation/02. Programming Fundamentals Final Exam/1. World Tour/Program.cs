using System;

namespace _1._World_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] commands = Console.ReadLine().Split(':');

            while (commands[0] != "Travel")
            {
                if (commands[0] == "Add Stop")
                {
                    int index = int.Parse(commands[1]);
                    if (index >= 0 && index <= input.Length - 1)
                    {
                        string text = commands[2];
                        input = input.Insert(index, text);
                    }
                }
                else if (commands[0] == "Remove Stop")
                {
                    int startIndex = int.Parse(commands[1]);
                    int endIndex = int.Parse(commands[2]);

                    if ((startIndex >= 0 && startIndex <= input.Length - 1) &&
                        (endIndex >= 0 && endIndex <= input.Length - 1) &&
                         endIndex >= startIndex)
                    {
                        int count = endIndex - startIndex + 1;
                        input = input.Remove(startIndex, count);
                    }
                }
                else if (commands[0] == "Switch")
                {
                    string oldText = commands[1];
                    string newText = commands[2];

                    if (input.Contains(oldText))
                    {
                        input = input.Replace(oldText, newText);
                    }
                }

                Console.WriteLine(input);
                commands = Console.ReadLine().Split(':');
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {input}");
        }
    }
}