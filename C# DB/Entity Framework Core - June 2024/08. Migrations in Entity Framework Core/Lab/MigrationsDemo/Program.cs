using MigrationsDemo.Data;
using MigrationsDemo.Data.Models;

namespace MigrationsDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var context = new SchoolDbContext())
            {
                // Add a new student
                context.Students.Add(new Student { FullName = "John Doe", Age = 20, Email = "johndoe@gmail.com" });
                context.Students.Add(new Student { FullName = "Jane Simmons", Age = 21, Email = "janesimmons@outlook.com" });
                context.Students.Add(new Student { FullName = "Alice Smith", Age = 22, Email = "alice_smith@gmail.com" });
                context.SaveChanges();

                // Query all students
                var students = context.Students.ToList();
                Console.WriteLine("All students in the database:");
                foreach (var student in students)
                {
                    Console.WriteLine($"- {student.FullName}, Age: {student.Age}, Email: {student.Email}");
                }
            }
        }
    }
}