namespace SquareRoot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int number = int.Parse(Console.ReadLine());
                IsTheNumberValid(number);
                PrintTheSquareRootOfTheNumber(number);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }
        }

        public static void IsTheNumberValid(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("Invalid number.");
            }
        }

        public static void PrintTheSquareRootOfTheNumber(int number) => Console.WriteLine(Math.Sqrt(number));
    }
}