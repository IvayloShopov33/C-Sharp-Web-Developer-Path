using System;
using System.Linq;

namespace _05._Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string expectedPassword = new string(username.Reverse().ToArray());
            int loginCounter=0;
            while (true)
            {
                string newUsername = Console.ReadLine();
                if (newUsername==expectedPassword)
                {
                    Console.WriteLine($"User {username} logged in.");
                    return;
                }
                else
                {
                    if (loginCounter == 3)
                    {
                        Console.WriteLine($"User {username} blocked!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect password. Try again.");
                        loginCounter++;
                    }
                }
            }
        }
    }
}
