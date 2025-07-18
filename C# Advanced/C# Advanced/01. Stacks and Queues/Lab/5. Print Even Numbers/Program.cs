namespace _5._Print_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queueOfNumbers = new Queue<int>();
            int[] arrayOfNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            foreach (int number in arrayOfNumbers)
            {
                queueOfNumbers.Enqueue(number);
            }

            List<int> numbers = new List<int>();
            foreach (int item in queueOfNumbers.ToList())
            {
                if (item % 2 == 0)
                {
                    int num = queueOfNumbers.Dequeue();
                    numbers.Add(num);
                }
                else
                {
                   queueOfNumbers.Dequeue();
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}