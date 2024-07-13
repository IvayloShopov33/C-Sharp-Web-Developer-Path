using AcademicRecordsApp.Data;
using AcademicRecordsApp.Data.Models;

namespace AcademicRecordsApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var db = new AcademicRecordsDbContext();

            var newStudent = new Student { FullName = "Ivaylo Shopov" };
            var course = new Course { Name = "C# DB" };

            db.Students.Add(newStudent);
            db.Courses.Add(course);

            db.SaveChanges();

            foreach (var student in db.Students.OrderBy(x => x.FullName))
            {
                Console.WriteLine($"{student.FullName} -> Courses: {string.Join(", ", student.Courses)}; Grades: {string.Join(", ", student.Grades)}");
            }
        }
    }
}