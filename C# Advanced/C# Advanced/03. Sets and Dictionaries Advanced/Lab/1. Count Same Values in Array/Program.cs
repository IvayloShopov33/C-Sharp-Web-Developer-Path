namespace _1._Count_Same_Values_in_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<double, int> numbersWithTheCountOfTheirOccurrences = new Dictionary<double, int>();
            double[] valuesOfTheNumbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            for (int i = 0; i < valuesOfTheNumbers.Length; i++)
            {
                //check if the element is not in the dictionary
                if (!numbersWithTheCountOfTheirOccurrences.ContainsKey(valuesOfTheNumbers[i]))
                {
                    //add the element to the dictionary
                    numbersWithTheCountOfTheirOccurrences.Add(valuesOfTheNumbers[i], 0);
                }

                //increase the value of the current key
                numbersWithTheCountOfTheirOccurrences[valuesOfTheNumbers[i]]++;
            }

            //print the keys with their values
            foreach (var number in numbersWithTheCountOfTheirOccurrences)
            {
                Console.WriteLine($"{number.Key} - {number.Value} times");
            }
        }
    }
}