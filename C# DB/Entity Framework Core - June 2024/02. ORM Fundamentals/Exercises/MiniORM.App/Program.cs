using MiniORM.App.Models;

namespace MiniORM.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Server=.;Integrated Security=true;Database=MiniORM;TrustServerCertificate=true";
            var dbContext = new MiniORMDbContext(connectionString);

            // Add
            dbContext.Projects.Add(new Project { Name = "MiniORM" });

            // Remove
            var projectToDelete = dbContext.Projects.FirstOrDefault(x => x.Name == "MiniORM");
            if (projectToDelete == null)
            {
                dbContext.Projects.Remove(projectToDelete);
            }

            // Update
            var employeesToUpdate = dbContext.Employees.Where(e => e.LastName == "Taylor" || !e.IsEmployed).ToList();
            foreach (var employee in employeesToUpdate)
            {
                employee.LastName = "Smith";
            }

            dbContext.SaveChanges();
        }
    }
}