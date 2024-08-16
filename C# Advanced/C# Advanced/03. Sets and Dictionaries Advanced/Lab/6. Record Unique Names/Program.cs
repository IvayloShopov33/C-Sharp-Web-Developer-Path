namespace _6._Record_Unique_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> names = new HashSet<string>();
            int namesCount = int.Parse(Console.ReadLine());
            for (int i = 1; i <= namesCount; i++)
            {
                string name = Console.ReadLine();
                //add the name to the hashset if it is not in him yet
                names.Add(name);
            }

            //print the unique names
            Console.WriteLine(string.Join(Environment.NewLine, names));
        }
    }
}