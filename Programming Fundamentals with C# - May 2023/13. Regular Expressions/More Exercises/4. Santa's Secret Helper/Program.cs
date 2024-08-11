using System;
using System.Text.RegularExpressions;
using System.Text;

namespace _4._Santa_s_Secret_Helper
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"[^\@\-\!\:\>]*\@(?<name>[A-Za-z]+)[^\@\-\!\:\>]*\!(?<behaviour>G|N)\!";
            int key = int.Parse(Console.ReadLine());
            string message = Console.ReadLine();
            StringBuilder stringBuilder = new StringBuilder();
            while (message!="end")
            {
                char[] messageToCharArray = message.ToCharArray();
                string decryptedMessage = string.Empty;
                foreach (char item in messageToCharArray)
                {
                    int newIndex = item - key;
                    decryptedMessage += (char)newIndex;
                }
                Match match = Regex.Match(decryptedMessage, pattern);
                if (match.Success && match.Groups["behaviour"].Value == "G")
                {
                    stringBuilder.AppendLine(match.Groups["name"].Value);
                }
                message = Console.ReadLine();
            }
            Console.WriteLine(stringBuilder);
        }
    }
}
