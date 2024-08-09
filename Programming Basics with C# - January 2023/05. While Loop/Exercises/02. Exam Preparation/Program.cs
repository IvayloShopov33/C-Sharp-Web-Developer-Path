using System;

namespace _02._Exam_Preparation
{
    class Program
    {
        static void Main(string[] args)
        {
         //брой незадаволителни оценки(които може да получи) сума на всички оценки, броя на всички оценки, брояч на незадоволителни оценки, име на последна задача
            int filledTimes = int.Parse(Console.ReadLine());
            int markSum = 0;            
            int markCount = 0;
            int filledCount = 0;
            string lastExercise = string.Empty;
            string input = Console.ReadLine();
            int mark;
            while (input!="Enough")
            {
                lastExercise = input;
                mark = int.Parse(Console.ReadLine());
                markSum += mark;
                markCount++;
                if (mark<=4)
                {
                    filledCount++;
                    if (filledCount==filledTimes)
                    {
                        Console.WriteLine($"You need a break, {filledCount} poor grades.");
                        break;
                    }
                }
                input = Console.ReadLine();
            }
            if (input=="Enough")
            {
                double average = (double)markSum / markCount;
                Console.WriteLine($"Average score: {average:f2}");
                Console.WriteLine($"Number of problems: {markCount}");
                Console.WriteLine($"Last problem: {lastExercise}");
            }
        }
    }
}
