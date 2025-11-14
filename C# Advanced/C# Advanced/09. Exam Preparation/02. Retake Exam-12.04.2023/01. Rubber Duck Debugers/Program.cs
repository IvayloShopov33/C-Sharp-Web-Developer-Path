namespace _01._Rubber_Duck_Debugers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> programmersTimes = new Queue<int>();
            Stack<int> tasksNumbers = new Stack<int>();

            List<int> times = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            List<int> tasks = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            foreach (int time in times)
            {
                programmersTimes.Enqueue(time);
            }

            foreach (int task in tasks)
            {
                tasksNumbers.Push(task);
            }

            int darthVaderDuckyCount = 0;
            int thorDuckyCount = 0;
            int bigBlueRubberDucky = 0;
            int smallYellowRubberDucky = 0;

            while (programmersTimes.Count > 0 && tasksNumbers.Count > 0)
            {
                int programmerTime = programmersTimes.Dequeue();
                int numberOfTask = tasksNumbers.Pop();
                int timeResult = programmerTime * numberOfTask;

                if (timeResult >= 0 && timeResult <= 60)
                {
                    darthVaderDuckyCount++;
                }
                else if (timeResult > 60 && timeResult <= 120)
                {
                    thorDuckyCount++;
                }
                else if (timeResult > 120 && timeResult <= 180)
                {
                    bigBlueRubberDucky++;
                }
                else if (timeResult > 180 && timeResult <= 240)
                {
                    smallYellowRubberDucky++;
                }
                else
                {
                    programmersTimes.Enqueue(programmerTime);
                    numberOfTask -= 2;
                    tasksNumbers.Push(numberOfTask);
                }
            }

            Console.WriteLine("Congratulations, all tasks have been completed! Rubber ducks rewarded:");
            Console.WriteLine($"Darth Vader Ducky: {darthVaderDuckyCount}");
            Console.WriteLine($"Thor Ducky: {thorDuckyCount}");
            Console.WriteLine($"Big Blue Rubber Ducky: {bigBlueRubberDucky}");
            Console.WriteLine($"Small Yellow Rubber Ducky: {smallYellowRubberDucky}");
        }
    }
}