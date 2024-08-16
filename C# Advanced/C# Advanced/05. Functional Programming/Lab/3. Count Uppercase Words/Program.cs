namespace _3._Count_Uppercase_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Func<string, bool> uppercaseCheck = word => char.IsUpper(word[0]);
            words = words.Where(uppercaseCheck).ToArray();
            Console.WriteLine(string.Join(Environment.NewLine, words));
        }
    }
}