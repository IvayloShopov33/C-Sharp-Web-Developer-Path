using System;

namespace _1._Activation_Keys
{
    class Program
    {
        static void Main(string[] args)
        {
            string activationKey = Console.ReadLine();
            string[] commands = Console.ReadLine().Split(">>>");

            while (commands[0] != "Generate")
            {
                if (commands[0] == "Contains")
                {
                    string substring = commands[1];

                    if (activationKey.Contains(substring))
                    {
                        Console.WriteLine($"{activationKey} contains {substring}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }
                else if (commands[0] == "Flip")
                {
                    int startIndex = int.Parse(commands[2]);
                    int endIndex = int.Parse(commands[3]);

                    string letters = activationKey.Substring(startIndex, endIndex - startIndex);
                    string newLetters = string.Empty;

                    if (commands[1] == "Upper")
                    {
                        newLetters = letters.ToUpper();
                    }
                    else if (commands[1] == "Lower")
                    {
                        newLetters = letters.ToLower();
                    }

                    activationKey = activationKey.Replace(letters, newLetters);
                    Console.WriteLine(activationKey);
                }
                else if (commands[0] == "Slice")
                {
                    int startingIndex = int.Parse(commands[1]);
                    int endingIndex = int.Parse(commands[2]);

                    activationKey = activationKey.Remove(startingIndex, endingIndex - startingIndex);
                    Console.WriteLine(activationKey);
                }

                commands = Console.ReadLine().Split(">>>");
            }

            Console.WriteLine($"Your activation key is: {activationKey}");
        }
    }
}