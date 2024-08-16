namespace _7._Predicate_for_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int namesValidLength = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();

            Predicate<int> isValidLength = x => x <= namesValidLength;
            foreach (string name in names)
            {
                if (isValidLength(name.Length))
                {
                    Console.WriteLine(name);
                }
            }
        }
    }
}