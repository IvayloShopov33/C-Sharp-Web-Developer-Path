namespace _2._Stack_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stackOfNumbers = new Stack<int>();
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            foreach (int number in numbers)
            {
                stackOfNumbers.Push(number);
            }
            string[] commands = Console.ReadLine().Split();
            string action = commands[0].ToLower();
            while (action != "end")
            {
                int firstNumber = int.Parse(commands[1]);
                if (action=="add")
                {
                    int secondNumber = int.Parse(commands[2]);
                    stackOfNumbers.Push(firstNumber);
                    stackOfNumbers.Push(secondNumber);
                }
                else if (action=="remove")
                {
                    if (stackOfNumbers.Count>=firstNumber)
                    {
                        for (int i = 0; i < firstNumber; i++)
                        {
                            stackOfNumbers.Pop();
                        }
                    }
                }
                commands = Console.ReadLine().Split();
                action = commands[0].ToLower();
            }
            Console.WriteLine($"Sum: {stackOfNumbers.Sum()}");
        }
    }
}