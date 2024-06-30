using MiniORM.App.Models;

namespace MiniORM.App
{
    public class MiniORMDbContext : DbContext
    {
        public MiniORMDbContext(string connectionString) 
            : base(connectionString)
        {

        }

        public DbSet<Department> Departments { get; } = null!;
        public DbSet<Employee> Employees { get; } = null!;
        public DbSet<Project> Projects { get; } = null!;
        public DbSet<EmployeeProject> EmployeesProjects { get; } = null!;
    }
}
