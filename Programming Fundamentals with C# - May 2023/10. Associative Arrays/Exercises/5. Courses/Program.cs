using System;
using System.Collections.Generic;

namespace _5._Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses =
                new Dictionary<string, List<string>>();
            InitializeCourses(courses);
            PrintCoursesWithTheirStudents(courses);
        }

        static void InitializeCourses(Dictionary<string, List<string>> courses)
        {
            string[] coursesDetails = Console.ReadLine().Split(" : ");
            while (coursesDetails[0] != "end")
            {
                string courseName = coursesDetails[0];
                string studentName = coursesDetails[1];
                if (!courses.ContainsKey(courseName))
                {
                    courses.Add(courseName, new List<string>());
                }
                courses[courseName].Add(studentName);
                coursesDetails = Console.ReadLine().Split(" : ");
            }
        }

        static void PrintCoursesWithTheirStudents(Dictionary<string, List<string>> courses)
        {
            foreach (var course in courses)
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count}");
                for (int i = 0; i < course.Value.Count; i++)
                {
                    Console.WriteLine($"-- {course.Value[i]}");
                }
            }
        }
    }
}
