using System;
using System.Collections.Generic;

namespace _5._Students_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            List<Student> students = new List<Student>();
            while (input[0] != "end")
            {
                string firstName = input[0];
                string lastName = input[1];
                string age = input[2];
                string homeTown = input[3];
                bool studentExist = studentIsExisting(students, firstName, lastName, age, homeTown);

                if (!studentExist)
                {
                    Student student = new Student
                    {
                        firstName = firstName,
                        lastName = lastName,
                        age = age,
                        homeTown = homeTown
                    };
                    students.Add(student);
                }
                input = Console.ReadLine().Split();
            }

            string givenCity = Console.ReadLine();

            foreach (var student in students)
            {
                if (student.homeTown == givenCity)
                {
                    Console.WriteLine($"{student.firstName} {student.lastName} is {student.age} years old.");
                }
            }
        }

        private static bool studentIsExisting(List<Student> students, string firstName, string lastName, string age, string homeTown)
        {
            foreach (Student student in students)
            {
                if (student.firstName == firstName && student.lastName == lastName)
                {
                    student.age = age;
                    student.homeTown = homeTown;
                    return true;
                }
            }
            return false;
        }
    }

    public class Student
    {
        public string firstName { get; set; }

        public string lastName { get; set; }
        public string age { get; set; }

        public string homeTown { get; set; }       
    }

}
