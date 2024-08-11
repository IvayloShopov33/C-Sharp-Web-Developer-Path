using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _2._Emoji_Detector
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(\:{2}|\*{2})(?<emoji>[A-Z][a-z]{2,})\1";
            string input = Console.ReadLine();
            int coolThreshold = 1;
            foreach (char item in input)
            {
                if (char.IsDigit(item))
                {
                    int digit = int.Parse(item.ToString());
                    coolThreshold *= digit;
                }
            }
            MatchCollection matchCollection = Regex.Matches(input, pattern);
            List<string> coolEmojis = new List<string>();
            foreach (Match match in matchCollection)
            {
                CaptureCollection captureCollection = match.Groups["emoji"].Captures;
                string emojiToString = string.Empty;
                foreach (var item in captureCollection)
                {
                    emojiToString += item;
                }
                int asciiCode = 0;
                foreach (char item in emojiToString)
                {
                    asciiCode += item;
                }
                if (asciiCode > coolThreshold)
                {
                    coolEmojis.Add(match.Value);
                }
            }
            Console.WriteLine($"Cool threshold: {coolThreshold}");
            Console.WriteLine($"{matchCollection.Count} emojis found in the text. The cool ones are:");
            foreach (string emoji in coolEmojis)
            {
                Console.WriteLine(emoji);
            }
        }
    }
}
