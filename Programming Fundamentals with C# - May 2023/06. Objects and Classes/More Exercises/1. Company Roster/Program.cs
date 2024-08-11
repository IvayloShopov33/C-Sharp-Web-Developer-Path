using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Company_Roster
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            int employeesCount = int.Parse(Console.ReadLine());
            for (int i = 1; i <= employeesCount; i++)
            {
                string[] employeeDetails = Console.ReadLine().Split();
                string name = employeeDetails[0];
                double salary = double.Parse(employeeDetails[1]);
                string department = employeeDetails[2];
                Employee employee = new Employee(name, salary, department);
                employees.Add(employee);
            }
            var highestAverageSalaryDepartment = employees.GroupBy(f => f.Department).Select(g => new
            {
                Department = g.Key,
                AverageSalary = g.Average(e => e.Salary)
            }).OrderByDescending(g => g.AverageSalary).First();

            Console.WriteLine($"Highest Average Salary: {highestAverageSalaryDepartment.Department}");

            var employeesInDepartment = employees.Where(e => e.Department == highestAverageSalaryDepartment.Department)
                .OrderByDescending(e => e.Salary);
            foreach (var employee in employeesInDepartment)
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:f2}");
            }
        }
    }

    public class Employee
    {
        public Employee(string name, double salary, string department)
        {
            this.Name = name;
            this.Salary = salary;
            this.Department = department;
        }
        public string Name { get; private set; }
        public double Salary { get; private set; }
        public string Department { get; private set; }
    }
}
