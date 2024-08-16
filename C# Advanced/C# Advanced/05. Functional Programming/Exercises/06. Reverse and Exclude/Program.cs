namespace _6._Reverse_and_Exclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int divisor = int.Parse(Console.ReadLine());

            Func<int, int, bool> func = (x, y) => x % y == 0;
            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                if (!func(numbers[i], divisor))
                {
                    Console.Write(numbers[i] + " ");
                }
            }
        }
    }
}