using System;

namespace _01._Bonus_Scoring_System
{
    class Program
    {
        static void Main(string[] args)
        {
            int studentsCount = int.Parse(Console.ReadLine());
            int lecturesCount = int.Parse(Console.ReadLine());
            int additionalBonus = int.Parse(Console.ReadLine());
            
            int maxBonus = 0;
            double maxBonusDouble = 0;
            int attendances;
            double totalStudentBonus;
            int totalBonus;
            int studentWithHighestBonusAttendances = 0;
            
            for (int i = 1; i <= studentsCount; i++)
            {
                attendances = int.Parse(Console.ReadLine());
                totalStudentBonus = (attendances * 1.0 / lecturesCount) * (5 + additionalBonus);
                totalBonus = (int)Math.Ceiling(totalStudentBonus);
                
                if (maxBonusDouble < totalStudentBonus)
                {
                    maxBonusDouble = totalStudentBonus;
                    studentWithHighestBonusAttendances = attendances;
                    maxBonus = totalBonus;
                }
            }
            
            Console.WriteLine($"Max Bonus: {maxBonus}.");
            Console.WriteLine($"The student has attended {studentWithHighestBonusAttendances} lectures.");
        }
    }
}
