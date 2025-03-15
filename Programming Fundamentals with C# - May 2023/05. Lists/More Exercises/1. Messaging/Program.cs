using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Messaging
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string message = Console.ReadLine();
            
            List<char> messageToChar = message.ToList();
            int sumOfDigits;
            string finalMessage = string.Empty;
            
            for (int i = 0; i < numbers.Count; i++)
            {
                int number = numbers[i];
                sumOfDigits = 0;
                while (number != 0)
                {
                    int digit = number % 10;
                    sumOfDigits += digit;
                    number /= 10;
                }

                if (sumOfDigits <= messageToChar.Count - 1)
                {
                    for (int j = 0; j < messageToChar.Count; j++)
                    {
                        if (j == sumOfDigits)
                        {
                            finalMessage += messageToChar[j];
                            messageToChar.RemoveAt(j);
                            
                            break;
                        }
                    }
                }
                else
                {
                    while (sumOfDigits > messageToChar.Count - 1)
                    {
                        sumOfDigits -= messageToChar.Count;
                    }
                    
                    for (int j = 0; j < messageToChar.Count; j++)
                    {
                        if (j == sumOfDigits)
                        {
                            finalMessage += messageToChar[j];
                            messageToChar.RemoveAt(j);
                            
                            break;
                        }
                    }
                }
            }
            
            Console.WriteLine(string.Join(' ', finalMessage));
        }
    }
}
