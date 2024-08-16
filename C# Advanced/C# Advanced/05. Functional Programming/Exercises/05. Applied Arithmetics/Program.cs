namespace _5._Applied_Arithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string command = string.Empty;

            while (true)
            {
                command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }
                else if (command == "print")
                {
                    Console.WriteLine(string.Join(' ', numbers));
                }
                else if (command == "add")
                {
                    Func<int, int> funcToAdd = num => num + 1;
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        numbers[i] = funcToAdd(numbers[i]);
                    }
                }
                else if (command == "subtract")
                {
                    Func<int, int> funcToSubtract = num => num - 1;
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        numbers[i] = funcToSubtract(numbers[i]);
                    }
                }
                else if (command == "multiply")
                {
                    Func<int, int> funcToMultiply = num => num * 2;
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        numbers[i] = funcToMultiply(numbers[i]);
                    }
                }
            }
        }
    }
}