using System;
using System.Collections.Generic;

namespace _1._Valid_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine().Split(", ");
            List<string> validUsernames = new List<string>();
            foreach (string username in usernames)
            {
                bool isVaild = true;
                if (username.Length >= 3 && username.Length <= 16)
                {
                    char[] usernameToCharArray = username.ToCharArray();
                    for (int i = 0; i < usernameToCharArray.Length; i++)
                    {
                        if (!char.IsDigit(usernameToCharArray[i]) && !char.IsLetter(usernameToCharArray[i])
                            && usernameToCharArray[i] != '-' && usernameToCharArray[i] != '_')
                        {
                            isVaild = false;
                            break;
                        }
                    }
                    if (isVaild)
                    {
                        validUsernames.Add(username);
                    }
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, validUsernames));
        }
    }
}
