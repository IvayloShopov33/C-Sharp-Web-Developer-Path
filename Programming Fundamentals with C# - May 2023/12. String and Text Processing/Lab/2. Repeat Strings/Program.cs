namespace _2._Repeat_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = System.Console.ReadLine().Split();
            string result = string.Empty;
            
            foreach (var word in words)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    result += word;
                }
            }
            
            System.Console.WriteLine(result);
        }
    }
}
