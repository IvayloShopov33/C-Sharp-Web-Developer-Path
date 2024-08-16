namespace _2._Sum_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(", ").Select(MyParse).ToArray();
            Console.WriteLine(numbers.Length);
            Console.WriteLine(numbers.Sum());
        }

        static int MyParse(string numberAsString)
        {
            int number = 0;
            foreach (char digit in numberAsString)
            {
                number *= 10;
                number += digit - '0';
            }

            return number;
        }
    }
}