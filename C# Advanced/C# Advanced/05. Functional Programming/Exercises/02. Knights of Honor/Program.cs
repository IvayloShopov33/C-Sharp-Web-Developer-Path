namespace _2._Knights_of_Honor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split();
            foreach (string name in names)
            {
                Action<string> printSirName = name => Console.WriteLine("Sir " + name);
                printSirName(name);
            }
        }
    }
}