using System;

namespace _2._Ascii_Sumator
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstChar = char.Parse(Console.ReadLine());
            char lastChar = char.Parse(Console.ReadLine());
            string textOfChars = Console.ReadLine();
            char[] textToCharArray = textOfChars.ToCharArray();
            int totalSumOfASCIICodes = 0;
            foreach  (char character in textToCharArray)
            {
                int firstCharASCIICode = firstChar;
                int lastCharASCIICode = lastChar;
                int currentCharASCIICode = character;
                if (currentCharASCIICode>firstCharASCIICode && currentCharASCIICode<lastCharASCIICode)
                {
                    totalSumOfASCIICodes += currentCharASCIICode;
                }
            }
            Console.WriteLine(totalSumOfASCIICodes);
        }
    }
}
