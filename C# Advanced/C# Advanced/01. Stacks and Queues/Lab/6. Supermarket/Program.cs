namespace _6._Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> clients = new Queue<string>();
            string nameOrCommand = Console.ReadLine();
            while (nameOrCommand != "End")
            {
                if (nameOrCommand == "Paid" && clients.Count > 0)
                {
                    foreach (string item in clients.ToList())
                    {
                        Console.WriteLine(clients.Dequeue());
                    }
                }
                else
                    clients.Enqueue(nameOrCommand);

                nameOrCommand = Console.ReadLine();
            }
            Console.WriteLine($"{clients.Count} people remaining.");
        }
    }
}