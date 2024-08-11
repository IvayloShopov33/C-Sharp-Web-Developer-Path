using System;

namespace _6.__Tri_bit_Switch
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputNumber = int.Parse(Console.ReadLine());
            int initialPosition = int.Parse(Console.ReadLine());
            string numberToBinary = Convert.ToString(inputNumber, 2);
            char[] binaryToCharArray = numberToBinary.ToCharArray();
            Array.Reverse(binaryToCharArray);
            for (int i = initialPosition; i < initialPosition+3; i++)
            {
                if (binaryToCharArray[i]=='0')
                {
                    binaryToCharArray[i] = '1';
                }
                else if (binaryToCharArray[i]=='1')
                {
                    binaryToCharArray[i] = '0';
                }
            }
            Array.Reverse(binaryToCharArray);
            string newDecimalNumberToString = string.Empty;
            for (int i = 0; i < binaryToCharArray.Length; i++)
            {
                newDecimalNumberToString += binaryToCharArray[i];
            }

            string newNumber = Convert.ToInt32(newDecimalNumberToString, 2).ToString();
            Console.WriteLine(newNumber);
        }
    }
}
