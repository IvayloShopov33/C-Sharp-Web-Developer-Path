using System;

namespace _06._Vowels_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int sum = 0;
            for (int i=0; i<text.Length; i++)
            {
                char character = text[i];
                if (character=='a')
                {
                    sum = sum + 1;
                }
                else if (character=='e')
                {
                    sum = sum + 2;
                }
                else if (character=='i')
                {
                    sum = sum + 3;
                }
                else if (character=='o')
                {
                    sum = sum + 4;
                }
                else if (character=='u')
                {
                    sum = sum + 5;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
