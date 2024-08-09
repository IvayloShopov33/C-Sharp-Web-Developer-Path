using System;

namespace _08._Graduation
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int grade = 1;
            int classRepetition = 0;
            double markSum = 0;
            while (grade<=12)
            {
                double currentGradeMark = double.Parse(Console.ReadLine());
                if (currentGradeMark<4)
                {
                    classRepetition++;
                    if (classRepetition>1)
                    {
                        break;
                    }
                    continue;
                }
                markSum += currentGradeMark;
                grade++;
            }
            //Two ways to come here-natural(end command-13>12) & forced(break)
            if (classRepetition>1)
            {
                //excluded
                Console.WriteLine($"{name} has been excluded at {grade} grade");
            }
            else
            {
                //graduated
                double averageMark = markSum / (grade - 1);
                Console.WriteLine($"{name} graduated. Average grade: {averageMark:f2}");
            }
        }
    }
}
