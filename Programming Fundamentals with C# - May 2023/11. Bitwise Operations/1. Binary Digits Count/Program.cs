using System;

namespace _1._Binary_Digits_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            int decimalNumber = int.Parse(Console.ReadLine());
            char binaryNumber =char.Parse(Console.ReadLine());
            string decimalNumberToString = Convert.ToString(decimalNumber, 2);
            char[] binaryNumberToCharArray = decimalNumberToString.ToCharArray();
            int equalNumbersCount = 0;
            foreach (var character in binaryNumberToCharArray)
            {
                if (character==binaryNumber)
                {
                    equalNumbersCount++;
                }
            }
            Console.WriteLine(equalNumbersCount);
        }
    }
}
