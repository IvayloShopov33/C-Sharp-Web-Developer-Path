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
                        FirstName = firstName,
                        LastName = lastName,
                        Age = age,
                        HomeTown = homeTown
                    };
                    
                    students.Add(student);
                }
                
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

        private static bool studentIsExisting(List<Student> students, string firstName, string lastName, string age, string homeTown)
        {
            foreach (Student student in students)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    student.Age = age;
                    student.HomeTown = homeTown;
                    
                    return true;
                }
            }
            
            return false;
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
