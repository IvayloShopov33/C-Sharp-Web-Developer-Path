using System;
using System.Collections.Generic;
using System.Text;

namespace MorseCodeTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            string morseCode = Console.ReadLine();

            string[] words = morseCode.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder translatedMessage = new StringBuilder();

            foreach (string word in words)
            {
                string[] letters = word.Split(' ');
                StringBuilder translatedWord = new StringBuilder();

                foreach (string letter in letters)
                {
                    if (MorseCodeDictionary.ContainsKey(letter))
                    {
                        char translatedLetter = MorseCodeDictionary[letter];
                        translatedWord.Append(translatedLetter);
                    }
                }

                translatedMessage.Append(translatedWord).Append(' ');
            }

            string finalMessage = translatedMessage.ToString().Trim();
            Console.WriteLine(finalMessage);
        }

        static Dictionary<string, char> MorseCodeDictionary = new Dictionary<string, char>()
        {
            {".-", 'A'},
            {"-...", 'B'},
            {"-.-.", 'C'},
            {"-..", 'D'},
            {".", 'E'},
            {"..-.", 'F'},
            {"--.", 'G'},
            {"....", 'H'},
            {"..", 'I'},
            {".---", 'J'},
            {"-.-", 'K'},
            {".-..", 'L'},
            {"--", 'M'},
            {"-.", 'N'},
            {"---", 'O'},
            {".--.", 'P'},
            {"--.-", 'Q'},
            {".-.", 'R'},
            {"...", 'S'},
            {"-", 'T'},
            {"..-", 'U'},
            {"...-", 'V'},
            {".--", 'W'},
            {"-..-", 'X'},
            {"-.--", 'Y'},
            {"--..", 'Z'}
        };
    }
}
