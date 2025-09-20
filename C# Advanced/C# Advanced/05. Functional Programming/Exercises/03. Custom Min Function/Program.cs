namespace _3._Custom_Min_Function
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int smallestNumber = TakeTheSmallestNumber(numbers);
            Console.WriteLine(smallestNumber);
        }

        static int TakeTheSmallestNumber(int[] numbers)
        {
            Func<int, int, bool> func = (x, y) => x > y;
            int minNumber = int.MaxValue;

            foreach (var number in numbers)
            {
                // check if the current number is smaller than the current minimum number
                if (func(minNumber, number))
                {
                    minNumber = number;
                }
            }

            return minNumber;
        }
    }
}