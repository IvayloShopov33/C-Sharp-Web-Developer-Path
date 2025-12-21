namespace EnterNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[10];
            int validNumbersCount = 0;

            while (validNumbersCount < 10)
            {
                try
                {
                    int number = int.Parse(Console.ReadLine());
                    IsTheNumberValid(number, numbers, validNumbersCount);
                    validNumbersCount = AddTheNumberToTheArray(numbers, validNumbersCount, number);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid Number!");
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }

        public static void IsTheNumberValid(int number, int[] numbers, int validNumbersCount)
        {
            if (numbers[0] == 0 && (number < 2 || number > 99))
            {
                throw new ArgumentException("Your number is not in range 1 - 100!");
            }
            else if (validNumbersCount != 0)
            {
                if (numbers[validNumbersCount - 1] >= number)
                {
                    throw new ArgumentException($"Your number is not in range {numbers[validNumbersCount - 1]} - 100!");
                }
            }
        }

        public static int AddTheNumberToTheArray(int[] numbers, int validNumbersCount, int number)
        {
            if (numbers[validNumbersCount] == 0 && validNumbersCount != 0)
            {
                if (numbers[validNumbersCount - 1] < number)
                {
                    numbers[validNumbersCount] = number;
                }
                else
                {
                    IsTheNumberValid(number, numbers, validNumbersCount);
                }
            }
            else if (validNumbersCount == 0)
            {
                numbers[validNumbersCount] = number;
            }

            validNumbersCount++;

            return validNumbersCount;
        }
    }
}