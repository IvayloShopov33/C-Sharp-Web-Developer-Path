namespace SumOfIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] inputNumbers = Console.ReadLine().Split(" ");
            int currentNumber = 0;
            int totalSum = 0;

            for (int i = 0; i < inputNumbers.Length; i++)
            {
                try
                {
                    currentNumber = int.Parse(inputNumbers[i]);
                    totalSum += currentNumber;
                }
                catch (FormatException)
                {
                    Console.WriteLine($"The element '{inputNumbers[i]}' is in wrong format!");
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"The element '{inputNumbers[i]}' is out of range!");
                }
                finally
                {
                    Console.WriteLine($"Element '{inputNumbers[i]}' processed - current sum: {totalSum}");
                }
            }

            Console.WriteLine($"The total sum of all integers is: {totalSum}");
        }
    }
}