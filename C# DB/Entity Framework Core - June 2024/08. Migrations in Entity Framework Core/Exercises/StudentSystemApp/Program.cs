using StudentSystemApp.Data;
using StudentSystemApp.Data.Models;
using StudentSystemApp.Data.Models.Enums;

namespace StudentSystemApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var db = new StudentSystemContext();

            var newCourse = new Course
            {
                Name = "C# DB",
                StartDate = DateTime.Parse("17.06.2024"),
                EndDate = DateTime.UtcNow,
                Price = 490.00m,
            };

            var newResource = new Resource
            {
                Name = "EF Core Introduction",
                Url = "https://softuni.bg/trainings/resources/video/100856/video-20-june-2024-stamo-petkov-entity-framework-core-june-2024/4540",
                ResourceType = ResourceType.Video,
                CourseId = 1,
            };

            newCourse.Resources.Add(newResource);

            db.Courses.Add(newCourse);
            db.Resources.Add(newResource);
            db.SaveChanges();

            foreach (var resource in db.Resources.OrderBy(x => x.Name))
            {
                Console.WriteLine($"{resource.Name} -> {resource.ResourceType}");
            }
        }
    }
}