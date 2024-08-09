using System;

namespace _02._Password
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = Console.ReadLine();
            string newPassword = Console.ReadLine();
            //string newPassword;
            //while((newPassword=Console.ReadLine())!=password);
            while (newPassword!=password)
            {
                newPassword = Console.ReadLine();
            }
            Console.WriteLine($"Welcome {username}!");

        }
    }
}
