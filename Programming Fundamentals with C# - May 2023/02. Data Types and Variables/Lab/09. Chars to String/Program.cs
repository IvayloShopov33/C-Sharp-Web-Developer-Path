using System;
namespace _9._Chars_to_String
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstCharacter = char.Parse(Console.ReadLine());
            char secondCharacter = char.Parse(Console.ReadLine());
            char thirdCharacter = char.Parse(Console.ReadLine());
            char[] combinedCharacters = {firstCharacter, secondCharacter, thirdCharacter};
            Console.WriteLine(combinedCharacters);
        }
    }
}
