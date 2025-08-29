namespace _3._Periodic_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedSet<string> chemicalElements = new SortedSet<string>();
            int inputLinesCount = int.Parse(Console.ReadLine());

            for (int i = 1; i <= inputLinesCount; i++)
            {
                string[] inputElements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                foreach (string element in inputElements)
                {
                    chemicalElements.Add(element);
                }
            }
            
            Console.WriteLine(string.Join(' ', chemicalElements));
        }
    }
}