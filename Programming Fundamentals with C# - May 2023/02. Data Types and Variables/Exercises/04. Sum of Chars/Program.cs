using System;

namespace _04._Sum_of_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            int lettersCount = int.Parse(Console.ReadLine());
            int sum = 0;
            
            for (int i = 0; i < lettersCount; i++)
            {
                char letter = char.Parse(Console.ReadLine());
                sum += letter;
            }
            
            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}
