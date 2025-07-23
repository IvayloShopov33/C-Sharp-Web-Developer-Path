namespace _2._Basic_Queue_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>();
            int[] numbersToTakeAction = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < numbersToTakeAction[0]; i++)
            {
                //put the numbers to the queue
                queue.Enqueue(numbers[i]); 
            }
            
            for (int i = 0; i < numbersToTakeAction[1]; i++)
            {
                //remove N number from the queue
                queue.Dequeue();
            }

            //check if the queue is emty
            if (queue.Count == 0) 
            {
                Console.WriteLine(0);
            }
            else if (queue.Contains(numbersToTakeAction[2])) //check if the number J is present in the queue
            {
                Console.WriteLine("true");
            }
            else
            {
                //takes the smallest number from the queue
                Console.WriteLine(queue.Min());
            }
        }
    }
}