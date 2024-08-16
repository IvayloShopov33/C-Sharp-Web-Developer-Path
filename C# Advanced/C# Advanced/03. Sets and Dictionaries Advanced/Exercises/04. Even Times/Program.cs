namespace _4._Even_Times
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> numbers = new Dictionary<int, int>();
            int numbersCount = int.Parse(Console.ReadLine());
            for (int i = 1; i <= numbersCount; i++)
            {
                int inputNumber = int.Parse(Console.ReadLine());
                
                //check if the element is not present in the dictionary
                if (!numbers.ContainsKey(inputNumber))
                {
                    numbers.Add(inputNumber, 0);
                }

                //increase the value of this number
                numbers[inputNumber]++;
            }

            foreach (var number in numbers)
            {
                //check if the number is appeared an even number of times
                if (number.Value % 2 == 0)
                {
                    Console.WriteLine(number.Key);
                    break;
                }
            }
        }
    }
}
