namespace _01._Offroad_Challenge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> initialFuels = new();
            Queue<int> consumptionIndexes = new();
            Queue<int> neededAmountsOfFuel = new();

            List<int> fuels = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            List<int> indexesOfConsumption = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            List<int> fuelAmounts = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            foreach (int fuel in fuels)
            {
                initialFuels.Push(fuel);
            }

            foreach (int index in indexesOfConsumption)
            {
                consumptionIndexes.Enqueue(index);
            }

            foreach (int fuel in fuelAmounts)
            {
                neededAmountsOfFuel.Enqueue(fuel);
            }

            int reachedAltitudeCount = 0;
            bool journeyIsOver = false;

            while (initialFuels.Count > 0 && consumptionIndexes.Count > 0 && neededAmountsOfFuel.Count > 0)
            {
                int fuel = initialFuels.Pop();
                int consumptionIndex = consumptionIndexes.Dequeue();

                if (fuel - consumptionIndex >= neededAmountsOfFuel.First())
                {
                    Console.WriteLine($"John has reached: Altitude {++reachedAltitudeCount}");
                    neededAmountsOfFuel.Dequeue();
                }
                else
                {
                    Console.WriteLine($"John did not reach: Altitude {++reachedAltitudeCount}");
                    Console.WriteLine("John failed to reach the top.");

                    if (reachedAltitudeCount == 1)
                    {
                        Console.WriteLine("John didn't reach any altitude.");
                    }
                    else
                    {
                        string[] reachedAltitudes = new string[reachedAltitudeCount - 1];
                        for (int i = 1; i < reachedAltitudeCount; i++)
                        {
                            reachedAltitudes[i - 1] = "Altitude " + i.ToString();
                        }

                        Console.WriteLine($"Reached altitudes: {string.Join(", ", reachedAltitudes)}");
                    }

                    journeyIsOver = true;
                    break;
                }
            }

            if (!journeyIsOver)
            {
                Console.WriteLine("John has reached all the altitudes and managed to reach the top!");
            }
        }
    }
}