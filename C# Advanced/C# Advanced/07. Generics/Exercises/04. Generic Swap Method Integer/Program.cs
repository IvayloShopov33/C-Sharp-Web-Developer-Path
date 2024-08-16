namespace _04._Generic_Swap_Method_Integer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();

            int numbersCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < numbersCount; i++)
            {
                int number = int.Parse(Console.ReadLine());
                numbers.Add(number);
            }

            int[] indexes = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int firstIndex = indexes[0];
            int secondIndex = indexes[1];

            if (IsInside<int>(numbers, firstIndex, secondIndex))
            {
                SwapAndPrintElements<int>(numbers, firstIndex, secondIndex);
            }
        }

        public static void SwapAndPrintElements<T>(List<T> values, int firstIndex, int secondIndex)
        {
            T tempValue = values[firstIndex];
            values[firstIndex] = values[secondIndex];
            values[secondIndex] = tempValue;

            foreach (T value in values)
            {
                Type type = value.GetType();
                Console.WriteLine($"{type}: {value}");
            }
        }

        public static bool IsInside<T>(List<T> numbers, int firstIndex, int secondIndex)
        {
            return firstIndex >= 0 && firstIndex < numbers.Count &&
                secondIndex >= 0 && secondIndex < numbers.Count;
        }
    }
}