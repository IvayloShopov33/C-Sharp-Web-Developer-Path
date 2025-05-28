using System;
using System.Text;

namespace _5._Multiply_Big_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            string secondNumber = Console.ReadLine();
            
            if (number == "0" || secondNumber == "0")
            {
                Console.WriteLine("0");
            }
            else
            {
                int carry = 0;
                int multiplier = int.Parse(secondNumber);
                StringBuilder result = new StringBuilder();
                
                for (int i = number.Length - 1; i >= 0; i--)
                {
                    int digit = int.Parse(number[i].ToString());
                    int product = digit * multiplier + carry;
                    result.Insert(0, (char)(product % 10 + '0'));
                    carry = product / 10;
                }
                
                if (carry > 0)
                {
                    result.Insert(0, (char)(carry + '0'));
                }
                
                Console.WriteLine(new string(result.ToString()));
            }
        }
    }
}
