using System;

namespace _1._The_Imitation_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            string input;
            while ((input = Console.ReadLine()) != "Decode")
            {
                string[] commands = input.Split('|');
                if (commands[0] == "Move")
                {
                    int lettersCount = int.Parse(commands[1]);
                    string stringToMove = message.Substring(0, lettersCount);
                    message += stringToMove;
                    message = message.Remove(0, lettersCount);
                }
                else if (commands[0] == "Insert")
                {
                    int index = int.Parse(commands[1]);
                    string value = commands[2];
                    message = message.Insert(index, value);
                }
                else if (commands[0] == "ChangeAll")
                {
                    string substring = commands[1];
                    string replacement = commands[2];
                    message = message.Replace(substring, replacement);
                }
            }
            Console.WriteLine($"The decrypted message is: {message}");
        }
    }
}
