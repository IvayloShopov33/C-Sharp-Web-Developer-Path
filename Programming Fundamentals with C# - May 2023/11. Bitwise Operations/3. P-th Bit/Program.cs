using System;

namespace _3._P_th_Bit
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int positionOfElementToPrint = int.Parse(Console.ReadLine());
            
            string numberToBinary = Convert.ToString(number, 2);
            char[] binaryNumberToCharArray = numberToBinary.ToCharArray();
            Array.Reverse(binaryNumberToCharArray);
            
            if (positionOfElementToPrint > binaryNumberToCharArray.Length - 1)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(binaryNumberToCharArray[positionOfElementToPrint]);
            }
        }
    }
}
