using System;
using System.Linq;

namespace _02._The_Lift
{
    class Program
    {
        static void Main(string[] args)
        {
            int peopleWaiting = int.Parse(Console.ReadLine());
            int[] liftState = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int totalAvailableSpots = liftState.Length * 4 - liftState.Sum();
            int totalPeopleInQueue = peopleWaiting;

            for (int i = 0; i < liftState.Length; i++)
            {
                int availableSpots = 4 - liftState[i];

                if (peopleWaiting >= availableSpots)
                {
                    peopleWaiting -= availableSpots;
                    liftState[i] = 4;
                    totalAvailableSpots -= availableSpots;
                    totalPeopleInQueue -= availableSpots;
                }
                else
                {
                    liftState[i] += peopleWaiting;
                    totalAvailableSpots -= peopleWaiting;
                    totalPeopleInQueue -= peopleWaiting;
                    peopleWaiting = 0;
                }

                if (totalAvailableSpots == 0 || peopleWaiting == 0)
                {
                    break;
                }
            }

            if (peopleWaiting == 0 && totalAvailableSpots > 0)
            {
                Console.WriteLine("The lift has empty spots!");
                Console.WriteLine(string.Join(" ", liftState));
            }
            else if (peopleWaiting > 0 && totalAvailableSpots == 0)
            {
                Console.WriteLine($"There isn't enough space! {totalPeopleInQueue} people in a queue!");
                Console.WriteLine(string.Join(" ", liftState));
            }
            else
            {
                Console.WriteLine(string.Join(" ", liftState));
            }
        }
    }
}
