namespace _7._Hot_Potato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> participants = new Queue<string>();
            string[] names = Console.ReadLine().Split();
            int quantityOfToss = int.Parse(Console.ReadLine());

            foreach (string name in names)
            {
                participants.Enqueue(name);
            }

            int hotPotato = 1;
            while (true)
            {
                if (participants.Count == 1)
                {
                    Console.WriteLine("Last is "+ participants.Dequeue());
                    break;
                }

                if (hotPotato == quantityOfToss)
                {
                    Console.WriteLine("Removed " + participants.Dequeue());
                    hotPotato = 1;
                }
                else
                {
                    hotPotato++;
                    participants.Enqueue(participants.Dequeue());
                }
            }
        }
    }
}