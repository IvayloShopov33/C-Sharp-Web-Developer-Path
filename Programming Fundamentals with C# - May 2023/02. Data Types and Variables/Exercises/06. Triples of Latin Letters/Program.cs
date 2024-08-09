using System;

namespace _06._Triples_of_Latin_Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            int lettersCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < lettersCount; i++)
            {
                char firstLetter = (char)('a' + i);
                for (int j = 0; j < lettersCount; j++)
                {
                    char secondLetter = (char)('a' + j);
                    for (int k = 0; k < lettersCount; k++)
                    {
                        char thirdLetter = (char)('a' + k);
                        char [] letters ={ firstLetter, secondLetter, thirdLetter};
                        Console.WriteLine(letters);
                    }
                }
            }
        }
    }
}
