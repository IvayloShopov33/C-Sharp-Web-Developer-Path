using System;

namespace _4._Text_Filter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(", ");
            string stringToBan = Console.ReadLine();
            
            for (int i = 0; i < words.Length; i++)
            {
                stringToBan = stringToBan.Replace(words[i], new string('*', words[i].Length));
            }
            
            Console.WriteLine(stringToBan);
        }
    }
}
