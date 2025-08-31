namespace _5._Count_Symbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> charactersOccurrences = new SortedDictionary<char, int>();
            string inputText = Console.ReadLine();

            foreach (char @char in inputText)
            {
                // check if the character is not present in the sorted dictionary
                if (!charactersOccurrences.ContainsKey(@char))
                {
                    // add the character to the sorted dictionary
                    charactersOccurrences.Add(@char, 0);
                }

                // increase its value
                charactersOccurrences[@char]++;
            }

            // print all characters with their occurrences in ascending order
            foreach (var item in charactersOccurrences)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}