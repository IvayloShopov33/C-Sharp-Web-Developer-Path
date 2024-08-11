using System;
using System.Text;

namespace _6._Replace_Repeating_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputString = Console.ReadLine();
            StringBuilder newString = new StringBuilder();
            newString.Append(inputString[0]);
            for (int i = 1; i < inputString.Length; i++)
            {
                if (inputString[i]!=inputString[i-1])
                {
                    newString.Append(inputString[i]);
                }
            }
            Console.WriteLine(newString.ToString());
        }
    }
}
