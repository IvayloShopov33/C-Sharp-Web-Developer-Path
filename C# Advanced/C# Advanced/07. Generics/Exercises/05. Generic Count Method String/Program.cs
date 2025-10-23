namespace _05._Generic_Count_Method_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> strings = new List<string>();
            Box<string> box = new Box<string>(strings);
            int itemsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < itemsCount; i++)
            {
                string input = Console.ReadLine();
                strings.Add(input);
            }

            string itemToCompare = Console.ReadLine();
            int result = box.CalculateCountOfGreaterElements(itemToCompare);

            Console.WriteLine(result);
        }
    }
}