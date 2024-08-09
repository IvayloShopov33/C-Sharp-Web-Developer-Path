using System;

namespace _3._Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            int capacityOfElevator = int.Parse(Console.ReadLine());
            if (numberOfPeople<=capacityOfElevator)
            {
                Console.WriteLine('1');
            }
            else
            {
                int courses = numberOfPeople / capacityOfElevator;
                if (numberOfPeople % capacityOfElevator != 0)
                {
                    courses++;
                }
                Console.WriteLine(courses);
            }
        }
    }
}
