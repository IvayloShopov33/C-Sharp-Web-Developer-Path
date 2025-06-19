using System;
using System.Text.RegularExpressions;

namespace _6._Extract_Emails
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\b(?<user>[A-Za-z0-9]+([\._-][A-Za-z0-9]+)*)@(?<host>[A-Za-z0-9]+([\.-][A-Za-z0-9]+)*\.[A-Za-z]{2,})\b";
            string[] input = Console.ReadLine().Split();

            foreach (string item in input)
            {
                if (char.IsLetterOrDigit(item[0]))
                {
                    if (Regex.IsMatch(item, pattern))
                    {
                        if (char.IsPunctuation(item[^1]))
                        {
                            string newItem = item.Remove(item.Length - 1);
                            Console.WriteLine(newItem);
                        }
                        else
                        {
                            Console.WriteLine(item);
                        }
                    }
                }
            }
        }
    }
}