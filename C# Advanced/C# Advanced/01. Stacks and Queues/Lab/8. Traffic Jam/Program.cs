namespace _8._Traffic_Jam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>();
            int carsPassed = 0;

            int numberOfAllowedPassedCars = int.Parse(Console.ReadLine());
            string carOrCommand = Console.ReadLine();
            
            while (carOrCommand != "end")
            {
                if (carOrCommand == "green")
                {
                    int countOfCars = 0;
                    foreach (string car in queue.ToList())
                    {
                        if (countOfCars == numberOfAllowedPassedCars || queue.Count == 0)
                        {
                            break;
                        }

                        Console.WriteLine($"{queue.Dequeue()} passed!");
                        countOfCars++;
                        carsPassed++;
                    }
                }
                else
                {
                    queue.Enqueue(carOrCommand);
                }

                carOrCommand = Console.ReadLine();
            }

            Console.WriteLine($"{carsPassed} cars passed the crossroads.");
        }
    }
}