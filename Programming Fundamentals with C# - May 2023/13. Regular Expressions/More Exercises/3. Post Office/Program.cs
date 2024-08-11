using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

namespace _3._Post_Office
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex firstPartPattern =new Regex(@"(\#|\$|\%|\*|\&)(?<letters>[A-z]+)\1");
            Regex secondPartPattern = new Regex(@"(?<firstChar>\d{2})\:(?<wordLength>\d{2})");
            Regex thirdPartPattern = new Regex(@"^[A-Z][!-~]+");
            string[] input = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);
            StringBuilder stringBuilder = new StringBuilder();
            Match letterMatch = firstPartPattern.Match(input[0]);
            char[] letters = letterMatch.Groups["letters"].Value.ToCharArray();
            MatchCollection matchCollection = secondPartPattern.Matches(input[1]);
            List<int> wordsLength = new List<int>();
            for (int i = 0; i < letters.Length; i++)
            {
                foreach (Match match in matchCollection)
                {
                    int currentASCIICode = int.Parse(match.Groups["firstChar"].Value);
                    if (currentASCIICode==letters[i])
                    {
                        wordsLength.Add(int.Parse(match.Groups["wordLength"].Value)+1);
                        break;
                    }
                }
            }
            string[] thirdPart = input[2].Split();
            for (int j = 0; j < letters.Length; j++)
            {
                foreach (string item in thirdPart)
                {
                    Match currentWord = thirdPartPattern.Match(item);
                    if (currentWord.Success && letters[j]==currentWord.Value[0] && currentWord.Value.Length==wordsLength[j])
                    {
                        stringBuilder.AppendLine(currentWord.Value);
                        break;
                    }
                }
            }
            Console.WriteLine(stringBuilder);
        }
    }
}
