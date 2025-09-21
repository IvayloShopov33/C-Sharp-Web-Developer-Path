namespace _4._Find_Evens_or_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbersRangeBounds = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int lowerBound = numbersRangeBounds.Min();
            int upperBound = numbersRangeBounds.Max();
            string typeOfnumbersToPrint = Console.ReadLine();

            // create a function which check by default if the current number is even
            Func<int, bool> func = num => num % 2 == 0;

            if (typeOfnumbersToPrint == "odd")
            {
                func = num => Math.Abs(num) % 2 == 1;
            }

            for (int i = lowerBound; i <= upperBound; i++)
            {
                if (func(i))
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}