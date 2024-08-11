using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

namespace _2._Rage_Quit
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder outputMessage = new StringBuilder();
            Regex symbol = new Regex(@"[!-\/:-~ ]+");
            Regex multiplicate = new Regex(@"\d+");
            List<char> uniqueSymbols = new List<char>();
            string message = Console.ReadLine();
            MatchCollection symbolCollection = symbol.Matches(message);
            MatchCollection multiplaceCollection = multiplicate.Matches(message);
            for (int i = 0; i < symbolCollection.Count; i++)
            {
                char[] symbols = symbolCollection[i].Value.ToUpper().ToCharArray();
                int number = int.Parse(multiplaceCollection[i].Value);
                for (int j = number; j >= 1; j--)
                {
                    foreach (char item in symbols)
                    {
                        if (!uniqueSymbols.Contains(item))
                        {
                            uniqueSymbols.Add(item);
                        }
                        outputMessage.Append(item);
                    }
                }
            }
            Console.WriteLine($"Unique symbols used: {uniqueSymbols.Count}");
            Console.WriteLine(outputMessage);
        }
    }    
}
