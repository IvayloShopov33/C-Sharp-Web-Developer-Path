using System;

namespace _6._Middle_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            if ((text.Length-1)%2==0)
            {
                GetMiddleCharacter(text);
            }
            else
            {
                GetMiddleCharacterSecondOption(text);
            }
        }
        static void GetMiddleCharacter(string text)
        {
            char middlechar = text[(text.Length - 1)/2];
            Console.WriteLine(middlechar);
        }
        static void GetMiddleCharacterSecondOption(string text)
        {
            string middleCharacters = string.Empty;
            char middlechar1 = text[(text.Length - 1) / 2];
            char middlechar2 = text[((text.Length - 1) / 2)+1];
            middleCharacters += middlechar1;
            middleCharacters += middlechar2;
            Console.WriteLine(middleCharacters);
        }
    }
}
