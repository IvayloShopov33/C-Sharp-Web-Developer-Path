using System;
using System.Text;

namespace _4._Caesar_Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            char[] messageToCharArray = message.ToCharArray();
            StringBuilder encryptedMessage = new StringBuilder();
            
            foreach (char character in messageToCharArray)
            {
                int newCharPosition = (int)character + 3;
                char newChar = (char)newCharPosition;
                encryptedMessage.Append(newChar);
            }
            
            Console.WriteLine(encryptedMessage);
        }
    }
}
