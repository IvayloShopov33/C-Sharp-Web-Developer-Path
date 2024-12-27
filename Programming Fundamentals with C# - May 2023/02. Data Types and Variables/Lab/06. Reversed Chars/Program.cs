using System;
using System.Linq;

namespace _6._Reversed_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            char letter1 = char.Parse(Console.ReadLine());
            char letter2 = char.Parse(Console.ReadLine());
            char letter3 = char.Parse(Console.ReadLine());
            
            char[] reversedLetters = { letter3, letter2, letter1 };
            Console.WriteLine(string.Join(' ', reversedLetters));
        }
    }
}
