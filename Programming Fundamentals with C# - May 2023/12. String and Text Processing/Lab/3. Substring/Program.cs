using System;

namespace _3._Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string substring = Console.ReadLine();
            string secondString = Console.ReadLine();
            
            while (secondString.Contains(substring))
            {
                int indexOfTheSubstring = secondString.IndexOf(substring);
                secondString = secondString.Remove(indexOfTheSubstring, substring.Length);
            }
            
            Console.WriteLine(secondString);
        }
    }
}
