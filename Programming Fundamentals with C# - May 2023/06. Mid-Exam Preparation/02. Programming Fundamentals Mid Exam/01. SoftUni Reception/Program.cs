using System;

namespace _01._SoftUni_Reception
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstEmployeeEfficiency = int.Parse(Console.ReadLine());
            int secondEmployeeEfficiency = int.Parse(Console.ReadLine());
            int thirdEmployeeEfficiency = int.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());
            int possibleAnswersPerHour = firstEmployeeEfficiency + secondEmployeeEfficiency + thirdEmployeeEfficiency;
            int time = 0;
            while (studentsCount>0)
            {
                time++;
                if (time%4==0)
                {
                    time++;
                }
                studentsCount -= possibleAnswersPerHour;
            }
            Console.WriteLine($"Time needed: {time}h.");
        }
    }
}
