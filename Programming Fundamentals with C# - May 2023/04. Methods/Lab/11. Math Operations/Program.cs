using System;

namespace _11._Math_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            char operatorSign= char.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            if (operatorSign == '+')
                GetAdd(firstNumber, secondNumber);
            else if (operatorSign == '-')
                GetSubtract(firstNumber, secondNumber);
            else if (operatorSign == '*')
                GetMultiply(firstNumber, secondNumber);
            else if (operatorSign == '/')
                GetDivide(firstNumber,secondNumber);
        }
        static void GetAdd(int firstNumber, int secondNumber)
        {
            Console.WriteLine(firstNumber+secondNumber);
        }
        static void GetSubtract(int firstNumber, int secondNumber) 
        {
            Console.WriteLine(firstNumber-secondNumber);
        }
        static void GetMultiply(int firstNumber, int secondNumber) 
        {
            Console.WriteLine(firstNumber*secondNumber);
        }
        static void GetDivide(int firstNumber, int secondNumber)
        {
            Console.WriteLine(firstNumber/(secondNumber*1.0));
        }
    }
}
