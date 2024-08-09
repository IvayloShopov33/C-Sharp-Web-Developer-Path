using System;

namespace _1._Integer_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());
            int fourthtNumber = int.Parse(Console.ReadLine());
            int result = ((firstNumber + secondNumber) / thirdNumber) * fourthtNumber;
            Console.WriteLine(result);
        }
    }
}
