namespace _3._Simple_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<string> stack = new Stack<string>();
            int outputNumber = 0;
            string[] input = Console.ReadLine().Split();

            for (int i = input.Length - 1; i >= 0; i--)
            {
                stack.Push(input[i]);
            }

            for (int i = 0; i < input.Length; i++)
            {
                if (stack.Count == 0)
                {
                    break;
                }

                if (i == 0)
                {
                    outputNumber += int.Parse(stack.Pop());
                    continue;
                }

                if (input[i] == "+")
                {
                    stack.Pop();
                    outputNumber += int.Parse(stack.Pop());
                }
                else if (input[i] == "-")
                {
                    stack.Pop();
                    outputNumber-= int.Parse(stack.Pop());
                }
            }

            Console.WriteLine(outputNumber);
        }
    }
}