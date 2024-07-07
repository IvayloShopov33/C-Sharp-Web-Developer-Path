using Demo.Models;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var db = new ApplicationDbContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            var department = new Department { Name = "HR" };
            var address = new Address { Name = "Vitoshka street" };
            var footballClub = new Club { Name = "Football Club" };
            var sewingClub = new Club { Name = "Sewing Club" };

            for (int i = 1; i <= 10; i++)
            {
                var employee = new Employee
                {
                    Egn = $"012364789{i - 1}",
                    FirstName = $"Ivo{i}",
                    LastName = $"Shopov{i}",
                    Salary = 100 + i,
                    StartWorkDate = new DateTime(2015 + i, 1, 1),
                    DepartmentId = 1,
                    Department = department,
                    AddressId = 1,
                    Address = address
                };

                employee.Clubs.Add(footballClub);
                employee.Clubs.Add(sewingClub);

                department.Employees.Add(employee);
                address.Employees.Add(employee);

                db.Employees.Add(employee);
                db.Departments.Add(department);
                db.Addresses.Add(address);
                db.Clubs.Add(footballClub);
                db.Clubs.Add(sewingClub);
            }

            db.SaveChanges();

            Console.WriteLine($"Employees in department {department.Name} are {department.Employees.Count}");
        }
    }
}
