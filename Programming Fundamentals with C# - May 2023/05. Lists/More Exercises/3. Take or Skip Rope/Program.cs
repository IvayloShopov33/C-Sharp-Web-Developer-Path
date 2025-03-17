using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Take_or_Skip_Rope
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            List<char> messageToChar = message.ToList();
            
            List<int> numbersList = new List<int>();
            List<char> nonNumberList = new List<char>();
            List<int> takeList = new List<int>();
            List<int> skipList = new List<int>();
            
            string finalString = string.Empty;
            int count = 0;
            
            for (int i = 0; i < messageToChar.Count; i++)
            {
                if (char.IsDigit(messageToChar[i]))
                {
                    int currentDigit = int.Parse(messageToChar[i].ToString());
                    numbersList.Add(currentDigit);
                }
                else
                {
                    nonNumberList.Add(messageToChar[i]);
                }
            }

            for (int i = 0; i < numbersList.Count; i++)
            {
                if (i % 2 == 0)
                {
                    takeList.Add(numbersList[i]);
                }
                else
                {
                    skipList.Add(numbersList[i]);
                }
            }

            for (int i = 1; i <= numbersList.Count; i++)
            {
                if (i % 2 == 0)
                {
                    int currentNumber = skipList[0];
                    for (int j = 0; j < currentNumber; j++)
                    {
                        count++;
                    }
                    
                    skipList.RemoveAt(0);
                }
                else
                {
                    int currentNumber = takeList[0];
                    if (currentNumber + count > nonNumberList.Count)
                    {
                        currentNumber = nonNumberList.Count - count;
                    }

                    for (int j = 0; j < currentNumber; j++)
                    {
                        finalString += nonNumberList[count].ToString();
                        count++;
                    }
                    
                    takeList.RemoveAt(0);
                }
            }
            
            Console.WriteLine(finalString);
        }
    }
}
