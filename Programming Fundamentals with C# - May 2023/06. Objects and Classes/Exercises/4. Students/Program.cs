using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Students
{
    class Program
    {
        static void Main(string[] args)
        {
            int studentsCount = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>();
            for (int i = 1; i <= studentsCount; i++)
            {
                string[] studentDetails = Console.ReadLine().Split();
                string firstName = studentDetails[0];
                string lastName = studentDetails[1];
                float grade = float.Parse(studentDetails[2]);
                Student student = new Student(firstName, lastName, grade);
                students.Add(student);               
            }
            List<Student> arrangedStudents = students.OrderByDescending(x=> x.Grade).ToList();
            foreach (var student in arrangedStudents)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}: {student.Grade:f2}");
            }
        }
    }

    public class Student
    {

        public Student(string firstName, string lastName, float grade)
        {
            FirstName = firstName;
            LastName = lastName;
            Grade = grade;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public float Grade { get; set; }

    }
}
