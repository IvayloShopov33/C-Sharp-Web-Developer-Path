using System;

namespace _5._Decrypting_Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int lettersCount = int.Parse(Console.ReadLine());
            string message = string.Empty;
            for (int i = 0; i < lettersCount; i++)
            {
                char letter = char.Parse(Console.ReadLine());
                letter = (char)(letter + key);
                message += letter;
            }
            Console.WriteLine(message);
        }
    }
}
