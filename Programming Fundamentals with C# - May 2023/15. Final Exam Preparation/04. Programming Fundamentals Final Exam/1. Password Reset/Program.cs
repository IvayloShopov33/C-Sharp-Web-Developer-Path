using System;

namespace _1._Password_Reset
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            string[] commands = Console.ReadLine().Split();

            while (commands[0] != "Done")
            {
                if (commands[0] == "TakeOdd")
                {
                    for (int i = 0; i < password.Length; i++)
                    {
                        password = password.Remove(i, 1);
                    }
                }
                else if (commands[0] == "Cut")
                {
                    int index = int.Parse(commands[1]);
                    int length = int.Parse(commands[2]);

                    password = password.Remove(index, length);
                }
                else if (commands[0] == "Substitute")
                {
                    string substring = commands[1];
                    if (password.Contains(substring))
                    {
                        string substitute = commands[2];
                        password = password.Replace(substring, substitute);
                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                        commands = Console.ReadLine().Split();

                        continue;
                    }
                }

                Console.WriteLine(password);
                commands = Console.ReadLine().Split();
            }

            Console.WriteLine($"Your password is: {password}");
        }
    }
}