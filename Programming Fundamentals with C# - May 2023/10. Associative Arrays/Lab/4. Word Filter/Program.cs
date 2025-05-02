using System;
using System.Linq;

namespace _4._Word_Filter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split().ToArray();
            words = words.Where(g => g.Length % 2 == 0).ToArray();
            
            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}
