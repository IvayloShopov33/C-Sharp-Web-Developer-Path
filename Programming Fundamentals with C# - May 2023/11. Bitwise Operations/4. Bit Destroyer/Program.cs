using System;

namespace _4._Bit_Destroyer
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputNumber = int.Parse(Console.ReadLine());
            int position = int.Parse(Console.ReadLine());
            string inputNumberToBinary = Convert.ToString(inputNumber, 2);
            char[] numberBinaryToCharArray = inputNumberToBinary.ToCharArray();
            Array.Reverse(numberBinaryToCharArray);
            numberBinaryToCharArray[position] = '0';
            Array.Reverse(numberBinaryToCharArray);
            string numberToString = string.Empty;
            for (int i = 0; i < numberBinaryToCharArray.Length; i++)
            {
                numberToString += numberBinaryToCharArray[i];
            }
            string newDecimalNumber = Convert.ToInt32(numberToString, 2).ToString();
            Console.WriteLine(newDecimalNumber);
        }
    }
}
