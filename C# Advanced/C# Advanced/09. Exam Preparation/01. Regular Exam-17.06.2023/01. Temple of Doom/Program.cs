namespace _01._Temple_of_Doom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> tools = new Queue<int>();
            Stack<int> substances = new Stack<int>();
            List<int> toolsList = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            List<int> substancesList = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            List<int> challenges = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

            foreach (var tool in toolsList)
            {
                tools.Enqueue(tool);
            }

            foreach (var substance in substancesList)
            {
                substances.Push(substance);
            }

            while (tools.Count > 0 && substances.Count > 0 && challenges.Count > 0)
            {
                int tool = tools.Dequeue();
                int substance = substances.Pop();
                if (challenges.Any(x => x == tool * substance))
                {
                    challenges.Remove(tool * substance);
                }
                else
                {
                    tools.Enqueue(++tool);
                    if (--substance > 0)
                    {
                        substances.Push(substance);
                    }
                }
            }

            if (challenges.Count == 0)
            {
                Console.WriteLine("Harry found an ostracon, which is dated to the 6th century BCE.");
            }
            else
            {
                Console.WriteLine("Harry is lost in the temple. Oblivion awaits him.");
            }

            if (tools.Count > 0)
            {
                Console.WriteLine($"Tools: {string.Join(", ", tools)}");
            }

            if (substances.Count > 0)
            {
                Console.WriteLine($"Substances: {string.Join(", ", substances)}");
            }

            if (challenges.Count > 0)
            {
                Console.WriteLine($"Challenges: {string.Join(", ", challenges)}");
            }
        }
    }
}