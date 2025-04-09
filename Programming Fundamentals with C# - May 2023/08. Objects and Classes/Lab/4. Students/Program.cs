using System;
using System.Collections.Generic;

namespace _4._Students
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
                
                Student student = new Student
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Age = age,
                    HomeTown = homeTown,
                };
                
                students.Add(student);
                input = Console.ReadLine().Split();
            }

            string givenCity = Console.ReadLine();
            foreach (var student in students)
            {
                if (student.HomeTown == givenCity)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
                }
            }
        }
    }

    public class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        
        public string Age { get; set; }

        public string HomeTown { get; set; }
    }
}
