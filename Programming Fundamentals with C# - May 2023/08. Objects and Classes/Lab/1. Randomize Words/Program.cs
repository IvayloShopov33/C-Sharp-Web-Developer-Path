using System;

namespace _1._Randomize_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();
            for (int i = 0; i < words.Length; i++)
            {
                Random random = new Random();
                int randomIndex = random.Next(0, words.Length);
                string currentWord = words[i];
                string randomWord = words[randomIndex];
                words[i] = randomWord;
                words[randomIndex] = currentWord;
            }
            Console.WriteLine(string.Join(Environment.NewLine, words));
        }
    }
}
