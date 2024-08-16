namespace _3._Maximum_and_Minimum_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stackOfNumbers= new Stack<int>();
            int queries=int.Parse(Console.ReadLine());
            int[] numbers;
            for (int i = 1; i <= queries; i++)
            {
                numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                if (numbers[0] == 1)
                    stackOfNumbers.Push(numbers[1]); //push number to the stack
                else if (numbers[0] == 2)
                    stackOfNumbers.Pop(); //remove the last entered element from the stack
                else if (numbers[0] == 3 && stackOfNumbers.Count>0)
                    Console.WriteLine(stackOfNumbers.Max()); //print the biggest number in the stack
                else if (numbers[0] == 4 && stackOfNumbers.Count>0)
                    Console.WriteLine(stackOfNumbers.Min()); //print the smallest number in the stack
            }
            
            Console.WriteLine(string.Join(", ", stackOfNumbers));
        }
    }
}
