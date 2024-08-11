using System;

namespace _7._Repeat_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            int strCount = int.Parse(Console.ReadLine());
            string finalString = RepeatString(str, strCount);
            Console.WriteLine(finalString);
        }
        static string RepeatString(string str, int strCount) 
        {
            string finalString = string.Empty;
            for (int i = 0; i < strCount; i++)
            {
                finalString += str;
            }
            return finalString;
        }
    }
}
