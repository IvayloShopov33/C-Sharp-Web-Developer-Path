using System;
using System.Text.RegularExpressions;

namespace _1._Winning_Ticket
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] tickets = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            string pattern = @"(\@{6,}|\${6,}|\^{6,}|#{6,})";
            Regex regex = new Regex(pattern);

            foreach (string ticket in tickets)
            {
                string trimmedTicket = ticket.Trim();
                if (trimmedTicket.Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                    continue;
                }

                string leftHalf = trimmedTicket.Substring(0, 10);
                string rightHalf = trimmedTicket[10..];

                Match leftMatch = regex.Match(leftHalf);
                Match rightMatch = regex.Match(rightHalf);

                if (leftMatch.Success && rightMatch.Success && leftMatch.Value[0] == rightMatch.Value[0])
                {
                    int matchLength = Math.Min(leftMatch.Length, rightMatch.Length);
                    string symbol = leftMatch.Value[0].ToString();

                    if (matchLength == 10)
                    {
                        Console.WriteLine($"ticket \"{trimmedTicket}\" - {matchLength}{symbol} Jackpot!");
                    }
                    else
                    {
                        Console.WriteLine($"ticket \"{trimmedTicket}\" - {matchLength}{symbol}");
                    }
                }
                else
                {
                    Console.WriteLine($"ticket \"{trimmedTicket}\" - no match");
                }
            }
        }
    }
}
