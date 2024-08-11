using System;

namespace _4._Tribonacci_Sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            TribonacciSequence(number);
        }
        static void TribonacciSequence(int number)
        {
            int[] numbers = new int[number];
            if (number>3)
            {
            numbers[0] = 1;
            numbers[1] = 1;
            numbers[2] = 2;
            for (int i = 3; i < number; i++)
            {
                numbers[i] = numbers[i - 3] + numbers[i - 2] + numbers[i - 1];
            }
            }
            else if (number==3)
            {
                numbers[0] = 1;
                numbers[1] = 1;
                numbers[2] = 2;
            }
            else if (number==2)
            {
                numbers[0] = 1;
                numbers[1] = 1;
            }
            else if (number==1)
            {
                numbers[0] = 1;

            }
            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
