namespace _1._Action_Point
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split();
            foreach (var name in names)
            {
                Action<string> printName = name => Console.WriteLine(name);
                printName(name);
            }
        }
    }
}