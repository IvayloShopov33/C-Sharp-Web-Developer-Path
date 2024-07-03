using SoftUni.Data;
using System.Text;
using SoftUni.Models;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var db = new SoftUniContext();

            // Task 3 - Employees Full Information
            Console.WriteLine(GetEmployeesFullInformation(db));

            // Task 4 - Employees with Salary Over 50 000
            Console.WriteLine(GetEmployeesWithSalaryOver50000(db));

            // Task 5 - Employees from Research and Development
            Console.WriteLine(GetEmployeesFromResearchAndDevelopment(db));

            // Task 6 - Adding a New Address and Updating Employee
            Console.WriteLine(AddNewAddressToEmployee(db));

            // Task 7 - Employees and Projects
            Console.WriteLine(GetEmployeesInPeriod(db));

            // Task 8 - Addresses by Town
            Console.WriteLine(GetAddressesByTown(db));

            // Task 9 - Employee 147
            Console.WriteLine(GetEmployee147(db));

            // Task 10 - Departments with More Than 5 Employees
            Console.WriteLine(GetDepartmentsWithMoreThan5Employees(db));

            // Task 11 - Find Latest 10 Projects
            Console.WriteLine(GetLatestProjects(db));

            // Task 12 - Increase Salaries
            Console.WriteLine(IncreaseSalaries(db));

            // Task 13 - Find Employees by First Name Starting With Sa
            Console.WriteLine(GetEmployeesByFirstNameStartingWithSa(db));

            // Task 14 - Delete Project by Id
            Console.WriteLine(DeleteProjectById(db));

            // Task 15 - Remove Town
            Console.WriteLine(RemoveTown(db));
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var output = new StringBuilder();
            var employees = context.Employees
                .Select(e => new { e.EmployeeId, e.FirstName, e.MiddleName, e.LastName, e.JobTitle, e.Salary })
                .OrderBy(x => x.EmployeeId)
                .ToList();

            foreach (var employee in employees)
            {
                output.AppendLine($"{employee.FirstName} {employee.MiddleName} {employee.LastName} {employee.JobTitle} {employee.Salary:f2}");
            }

            return output.ToString();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var output = new StringBuilder();
            var employeesWithSalaryOver50000 = context.Employees
                .Where(e => e.Salary > 50000)
                .Select(e => new { e.FirstName, e.Salary })
                .OrderBy(e => e.FirstName)
                .ToList();

            foreach (var employee in employeesWithSalaryOver50000)
            {
                output.AppendLine($"{employee.FirstName} - {employee.Salary:f2}");
            }

            return output.ToString();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var output = new StringBuilder();
            var employeesFromResearchAndDevelopment = context.Employees
                .Where(e => e.Department.Name == "Research and Development")
                .Select(e => new { e.FirstName, e.LastName, e.Department.Name, e.Salary })
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .ToList();

            foreach (var employee in employeesFromResearchAndDevelopment)
            {
                output.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.Name} - ${employee.Salary:f2}");
            }

            return output.ToString();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var output = new StringBuilder();
            var givenAddress = new Address { AddressText = "Vitoshka 15", TownId = 4 };
            context.Addresses.Add(givenAddress);

            var employeeWithNameNakov = context.Employees.FirstOrDefault(e => e.LastName == "Nakov");
            employeeWithNameNakov.Address = givenAddress;
            employeeWithNameNakov.AddressId = employeeWithNameNakov.Address.AddressId;
            context.SaveChanges();

            var employeesAddresses = context.Employees
                .Select(e => new { e.AddressId, e.Address.AddressText })
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .ToList();

            foreach (var employee in employeesAddresses)
            {
                output.AppendLine(employee.AddressText);
            }

            return output.ToString();
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var output = new StringBuilder();
            var employees = context.Employees
                .Select(e => new { e.EmployeeId, e.FirstName, e.LastName, ManagerFirstName = e.Manager.FirstName, ManagerLastName = e.Manager.LastName })
                .Take(10)
                .ToList();

            foreach (var employee in employees)
            {
                output.AppendLine($"{employee.FirstName} {employee.LastName} - Manager: {employee.ManagerFirstName} {employee.ManagerLastName}");
                var employeeProjects = context.EmployeesProjects
                    .Select(ep => new { ep.EmployeeId, ep.Project })
                    .Where(ep => ep.EmployeeId == employee.EmployeeId &&
                        ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003)
                    .ToList();

                foreach (var project in employeeProjects)
                {
                    if (project.Project.EndDate == null)
                    {
                        output.AppendLine($"--{project.Project.Name} - {project.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt")} - not finished");
                    }
                    else
                    {
                        output.AppendLine($"--{project.Project.Name} - {project.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt")} - {project.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt")}");
                    }
                }
            }

            return output.ToString();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var output = new StringBuilder();
            var addresses = context.Addresses
                .Select(a => new { a.AddressText, TownName = a.Town.Name, EmployeesCount = a.Employees.Count })
                .OrderByDescending(a => a.EmployeesCount)
                .ThenBy(a => a.TownName)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .ToList();

            foreach (var address in addresses)
            {
                output.AppendLine($"{address.AddressText}, {address.TownName} - {address.EmployeesCount} employees");
            }

            return output.ToString();
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            var output = new StringBuilder();
            var employeeWithId147 = context.Employees.Find(147);

            if (employeeWithId147 != null)
            {
                output.AppendLine($"{employeeWithId147.FirstName} {employeeWithId147.LastName} - {employeeWithId147.JobTitle}");

                var projectsOfThisEmployee = context.EmployeesProjects
                    .Select(ep => new { ep.EmployeeId, ep.Project })
                    .Where(ep => ep.EmployeeId == employeeWithId147.EmployeeId)
                    .OrderBy(ep => ep.Project.Name)
                    .ToList();

                foreach (var project in projectsOfThisEmployee)
                {
                    output.AppendLine($"{project.Project.Name}");
                }
            }

            return output.ToString();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var output = new StringBuilder();
            var departmentsWithMoreThan5Employees = context.Departments
                .Select(d => new { d.Name, ManagerFirstName = d.Manager.FirstName, ManagerLastName = d.Manager.LastName, d.Employees })
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .ToList();

            foreach (var department in departmentsWithMoreThan5Employees)
            {
                output.AppendLine($"{department.Name} - {department.ManagerFirstName} {department.ManagerLastName}");

                foreach (var employee in department.Employees.OrderBy(e => e.FirstName).ThenBy(e => e.LastName))
                {
                    output.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                }
            }

            return output.ToString();
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            var output = new StringBuilder();
            var latestProjects = context.Projects
                .Select(p => new { p.Name, p.Description, p.StartDate })
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .OrderBy(p => p.Name)
                .ToList();

            foreach (var project in latestProjects)
            {
                output.AppendLine(project.Name);
                output.AppendLine(project.Description);
                output.AppendLine(project.StartDate.ToString("M/d/yyyy h:mm:ss tt"));
            }

            return output.ToString();
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            var output = new StringBuilder();
            var givenDepartmentNames = new List<string>() { "Engineering", "Tool Design", "Marketing", "Information Services" };

            var employeesInTheseDepartments = context.Employees
                .Where(e => givenDepartmentNames.Contains(e.Department.Name))
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            foreach (var employee in employeesInTheseDepartments)
            {
                employee.Salary += 0.12m * employee.Salary;
                output.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:f2})");
            }

            return output.ToString();
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var output = new StringBuilder();
            var employeesByFirstNameStartingWithSa = context.Employees
                .Select(e => new { e.FirstName, e.LastName, e.JobTitle, e.Salary })
                .Where(e => e.FirstName.StartsWith("Sa"))
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            foreach (var employee in employeesByFirstNameStartingWithSa)
            {
                output.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:f2})");
            }

            return output.ToString();
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            var projectsReferencedToRemove = context.EmployeesProjects
                .Where(ep => ep.ProjectId == 2)
                .ToList();

            foreach (var project in projectsReferencedToRemove)
            {
                context.EmployeesProjects.Remove(project);
            }

            var projects = context.Projects
                .Where(ep => ep.ProjectId == 2)
                .ToList();

            foreach (var project in projects)
            {
                context.Projects.Remove(project);
            }

            context.SaveChanges();

            var projectsToPrint = context.Projects
                .Select(p => p.Name)
                .Take(10)
                .ToList();

            return string.Join(Environment.NewLine, projectsToPrint);
        }

        public static string RemoveTown(SoftUniContext context)
        {
            var employeesToChangeAddress = context.Employees
                .Where(e => e.Address.Town.Name == "Seattle")
                .ToList();

            foreach (var employee in employeesToChangeAddress)
            {
                employee.AddressId = null;
                employee.Address = null;
            }

            int countOfDeletedAddresses = 0;
            var addressesToDelete = context.Addresses
                .Where(a => a.Town.Name == "Seattle")
                .ToList();

            foreach (var address in addressesToDelete)
            {
                countOfDeletedAddresses++;
                context.Addresses.Remove(address);
            }

            var townToRemove = context.Towns.FirstOrDefault(t => t.Name == "Seattle");
            if (townToRemove != null)
            {
                context.Towns.Remove(townToRemove);
            }

            context.SaveChanges();

            return $"{countOfDeletedAddresses} addresses in Seattle were deleted";
        }
    }
}