using System;

namespace _04._Train_The_Trainers
{
    class Program
    {
        static void Main(string[] args)
        {
            int judgesMembers = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            string presentationName;
            int presentationCount=0;
            double grade=0;
            double averageGrade=0;
            while (input!="Finish")
            {
                presentationName = input;
                grade = 0;
                for (int i = 1; i <= judgesMembers; i++)
                {
                    grade += double.Parse(Console.ReadLine());
                }
                grade /= judgesMembers;
                Console.WriteLine($"{presentationName} - {grade:f2}.");
                averageGrade += grade;
                presentationCount++;
                input = Console.ReadLine();
            }
            Console.WriteLine($"Student's final assessment is {averageGrade/presentationCount:f2}.");
        }
    }
}
