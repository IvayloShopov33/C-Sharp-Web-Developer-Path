using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Student_Academy
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> students =
                new Dictionary<string, List<double>>();
            InitializeStudentsAndTheirGrades(students);
            PrintValidStudentsWithTheirGrades(students);
        }

        static void InitializeStudentsAndTheirGrades(Dictionary<string, List<double>> students)
        {
            int studentsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < studentsCount; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());
                if (!students.ContainsKey(name))
                {
                    students.Add(name, new List<double>());
                }
                students[name].Add(grade);
            }
        }

        static void PrintValidStudentsWithTheirGrades(Dictionary<string, List<double>> students)
        {
            foreach (KeyValuePair<string, List<double>> student in students)
            {

                double averageGrage = student.Value.Average();
                if (averageGrage >= 4.5 && averageGrage <= 6)
                {
                    Console.WriteLine($"{student.Key} -> {averageGrage:f2}");
                }
            }
        }
    }
}
