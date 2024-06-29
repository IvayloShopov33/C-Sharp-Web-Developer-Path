using Demo.Models;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var db = new SoftUni1Context();
            Console.WriteLine(db.Employees.Count());
            db.Towns.Add(new Town { Name = "Veliko Tarnovo" });
            db.SaveChanges();

            foreach (var town in db.Towns.OrderBy(x => x.Name))
            {
                Console.WriteLine(town.Name);
            }

            foreach (var employee in db.Employees
                .Where(x => x.FirstName.StartsWith("A"))
                .OrderByDescending(x => x.Salary)
                .Select(x => new { x.FirstName, x.LastName, x.Salary })
                .ToList())
            {
                Console.WriteLine($"{employee.FirstName} {employee.LastName} => {employee.Salary:f2}");
            }

            var departments = db.Employees
                .GroupBy(x => x.Department.Name)
                .Select(x => new { Name = x.Key, Count = x.Count() })
                .OrderByDescending(x => x.Count)
                .ToList();

            foreach (var department in departments)
            {
                Console.WriteLine($"{department.Name} => {department.Count} employees");
            }
        }
    }
}