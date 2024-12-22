using System;
using System.Globalization;
using System.Linq;

namespace _5.Messages_exception
{
    class Program
   {
       static void Main(string[] args)
        {
            int countOfLetters = int.Parse(Console.ReadLine());
            int i = 0;
            int offset = 0;
            string message = "";
           
            while (i < countOfLetters)
            {
                string input = Console.ReadLine();
                int numberOfDigits = input.Length;
                int mainDigit = input.ToString()[0] - '0';
                offset = (mainDigit - 2) * 3;
                
                if (mainDigit == 8 || mainDigit == 9)
                {
                    offset += 1;
                }
                
                int letterIndex = offset + numberOfDigits - 1;
                int asciiCode = letterIndex + 97;
                char letter = (char)asciiCode;
                
                message += letter;
                i++;
                
                if (mainDigit == 0)
                {
                   message = message.Replace("[", " ");
                }              
            }
           
            Console.WriteLine(message);
        }
    }
}
