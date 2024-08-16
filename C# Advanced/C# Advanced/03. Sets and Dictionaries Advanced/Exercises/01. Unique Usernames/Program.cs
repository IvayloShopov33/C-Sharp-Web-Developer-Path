namespace _1._Unique_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> usernames = new HashSet<string>();
            int inputLinesCount = int.Parse(Console.ReadLine());
            for (int i = 1; i <= inputLinesCount; i++)
            {
                string username = Console.ReadLine();
                usernames.Add(username);
            }
            
            Console.WriteLine(string.Join(Environment.NewLine, usernames));
        }
    }
}
