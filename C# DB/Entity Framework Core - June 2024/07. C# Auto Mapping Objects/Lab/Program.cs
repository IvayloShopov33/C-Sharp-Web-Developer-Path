using AutoMapper;
using AutoMapper.QueryableExtensions;
using Demo.Data;
using Demo.Data.Models;
using Demo.MapperProfiles;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var configuration = new MapperConfiguration(config =>
            {
                config.AddProfile<EmployeeDtoProfile>();
            });

            var mapper = configuration.CreateMapper();

            var db = new SoftUniContext();
            var employee = db.Employees
                .Include(e => e.Department)
                .Include(e => e.Manager)
                .Include(e => e.Address)
                .Include(e => e.Projects)
                .Where(x => x.EmployeeId == 1)
                .FirstOrDefault();

            var employeeDto = mapper.Map<EmployeeDto>(employee);
            Console.WriteLine(JsonConvert.SerializeObject(employeeDto, Formatting.Indented));

            var employees = db.Employees
                .Where(x => x.FirstName.StartsWith("G"))
                .ProjectTo<EmployeeDto>(configuration)
                .ToList();

            Console.WriteLine(JsonConvert.SerializeObject(employees, Formatting.Indented));

            EmployeeDto firstEmployeeDto = employees.FirstOrDefault();
            Employee dbEmployee = mapper.Map<Employee>(firstEmployeeDto);

            Console.WriteLine(JsonConvert.SerializeObject(dbEmployee, Formatting.Indented));
        }
    }

    public class EmployeeDto
    {
        public string FullName { get; set; }

        public string JobTitle { get; set; }

        public string DepartmentName { get; set; }

        public string ManagerFullName { get; set; }

        public string AddressText { get; set; }

        public decimal Salary { get; set; }

        public int ProjectsCount { get; set; }
    }
}