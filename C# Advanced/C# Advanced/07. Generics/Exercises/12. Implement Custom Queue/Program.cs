namespace _12._Implement_Custom_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomQueue<int> customQueue = new CustomQueue<int>();
            customQueue.Enqueue(1);
            customQueue.Enqueue(2);
            customQueue.Clear();
            customQueue.Enqueue(3);
            Console.WriteLine(customQueue.Peek());
            customQueue.Enqueue(4);
            customQueue.Enqueue(5);
            customQueue.Dequeue();
            customQueue.Enqueue(6);
            customQueue.ForEach(Console.WriteLine);

            CustomQueue<string> queue = new CustomQueue<string>();
            queue.Enqueue("hello");
            queue.Enqueue("world");
            queue.Clear();
            queue.Enqueue("Hello!");
            queue.Enqueue("Hi!");

            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }
        }
    }
}