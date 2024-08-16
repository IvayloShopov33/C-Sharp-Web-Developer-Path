namespace _2._Sets_of_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> firstNumbers = new HashSet<int>();
            HashSet<int> secondNumbers = new HashSet<int>();
            int[] setsLengths = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int number = 0;
            for (int i = 0; i < setsLengths[0]; i++)
            {
                number = int.Parse(Console.ReadLine());
                firstNumbers.Add(number);
            }

            for (int i = 0; i < setsLengths[1]; i++)
            {
                number = int.Parse(Console.ReadLine());
                secondNumbers.Add(number);
            }

            //check which hashset has less numbers
            if (firstNumbers.Count >= secondNumbers.Count)
            {
                PrintSameNumbersFromBothHashSets(firstNumbers, secondNumbers);
            }
            else
            {
                PrintSameNumbersFromBothHashSets(secondNumbers, firstNumbers);
            }
        }

        //This method prints the numbers which are in both of the hashsets
        static void PrintSameNumbersFromBothHashSets(HashSet<int> firstNumbers, HashSet<int> secondNumbers)
        {
            foreach (int number in secondNumbers)
            {
                //check if the number is present in the other hashset
                if (firstNumbers.Contains(number))
                {
                    Console.Write(number + " ");
                }
            }
        }
    }
}
