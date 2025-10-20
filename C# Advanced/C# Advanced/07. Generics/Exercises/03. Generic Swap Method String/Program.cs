namespace _03._Generic_Swap_Method_String
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<string> strings = new List<string>();
            int itemsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < itemsCount; i++)
            {
                string value = Console.ReadLine();
                strings.Add(value);
            }

            int[] indexes = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int firstIndex = indexes[0];
            int secondIndex = indexes[1];

            if (IsInside(strings, firstIndex, secondIndex))
            {
                SwapElementsAndPrintThem<string>(strings, firstIndex, secondIndex);
            }
        }

        public static void SwapElementsAndPrintThem<T>(List<T> values, int firstIndex, int secondIndex)
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

        public static bool IsInside(List<string> list, int firstIndex, int secondIndex)
        {
            return firstIndex >= 0 && firstIndex < list.Count &&
                secondIndex >= 0 && secondIndex < list.Count;
        }
    }
}