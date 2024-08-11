using System;
using System.Collections.Generic;

namespace _7._Company_Users
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companies =
                new Dictionary<string, List<string>>();
            InitializeCompaniesWithTheirEmployees(companies);
            PrintCompaniesWithTheirEmployees(companies);
        }

        static void InitializeCompaniesWithTheirEmployees(Dictionary<string, List<string>> companies)
        {
            string[] commands = Console.ReadLine().Split(" -> ");
            while (commands[0] != "End")
            {
                string company = commands[0];
                string employeeID = commands[1];
                if (!companies.ContainsKey(company))
                {
                    companies.Add(company, new List<string>());
                }
                if (!companies[company].Contains(employeeID))
                {
                    companies[company].Add(employeeID);
                }
                commands = Console.ReadLine().Split(" -> ");
            }
        }

        static void PrintCompaniesWithTheirEmployees(Dictionary<string, List<string>> companies)
        {
            foreach (KeyValuePair<string, List<string>> company in companies)
            {
                Console.WriteLine($"{company.Key}");
                for (int i = 0; i < company.Value.Count; i++)
                {
                    Console.WriteLine($"-- {company.Value[i]}");
                }
            }
        }
    }
}
