namespace _1._Basic_Stack_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stackOfTheNumbers = new Stack<int>();
            int[] numbersToTakeAction = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int i = 0; i < numbersToTakeAction[0]; i++)
            {
                //push the numbers to the stack
                stackOfTheNumbers.Push(numbers[i]);
            }
            
            for (int i = 0; i < numbersToTakeAction[1]; i++)
            {
                //remove N numbers from the stack
                stackOfTheNumbers.Pop();
            }
            
            //check if the stack is emty
            if (stackOfTheNumbers.Count == 0) 
            {
                Console.WriteLine(0);
            }
            else if (stackOfTheNumbers.Contains(numbersToTakeAction[2])) //check if the number M is present in the stack
            {
                Console.WriteLine("true");
            }
            else
            {
                //takes the smallest number from the stack
                Console.WriteLine(stackOfTheNumbers.Min());
            }
        }
    }
}
