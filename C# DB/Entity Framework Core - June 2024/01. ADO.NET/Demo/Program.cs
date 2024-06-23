using Microsoft.Data.SqlClient;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString =
                "Server=localhost;Integrated Security=true;Database=SoftUni1;TrustServerCertificate=true";

            using (var connection = 
                new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM [EMPLOYEES]";
                var sqlCommand = new SqlCommand(query, connection);
                var employeesCount = sqlCommand.ExecuteScalar();
                Console.WriteLine(employeesCount.ToString());

                string query1 = "UPDATE [EMPLOYEES] SET [SALARY] = [SALARY] + 20.5";
                var sqlCommand1 = new SqlCommand(query1, connection);
                int rowsAffected = sqlCommand1.ExecuteNonQuery();
                Console.WriteLine(rowsAffected);

                string query2 = "SELECT SUM(Salary) FROM [EMPLOYEES]";
                var sqlCommand2 = new SqlCommand(query2, connection);
                decimal employeesSalariesSum = (decimal)sqlCommand2.ExecuteScalar();
                Console.WriteLine($"{employeesSalariesSum:f2}");

                string query3 = "SELECT * FROM [EMPLOYEES] ORDER BY [FirstName]";
                var sqlCommand3 = new SqlCommand(query3, connection);

                using (SqlDataReader sqlDataReader = sqlCommand3.ExecuteReader())
                {
                    while (sqlDataReader.Read())
                    {
                        Console.WriteLine(sqlDataReader["FirstName"]);
                    }
                }

                var sqlCommand4 = new SqlCommand(
                    "SELECT d.[Name], COUNT(*) AS [EmployeesCount] " +
                    "FROM [Employees] e " +
                    "JOIN [Departments] d ON d.[DepartmentId] = e.[DepartmentId] " +
                    "GROUP BY d.[Name] " +
                    "ORDER BY [EmployeesCount] DESC", connection);

                using (SqlDataReader reader = sqlCommand4.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["Name"]} => {reader["EmployeesCount"]}");
                    }
                }

                // Preventing SQL Injection (via SqlParameter)
                string username = Console.ReadLine();
                string password = Console.ReadLine();
                var sqlCommand5 = new SqlCommand(
                    "SELECT COUNT(*) FROM [Users] WHERE [Username] = '@Username' AND [Password] = '@Password'",
                    connection);

                sqlCommand5.Parameters.Add(new SqlParameter("@Username", username));
                sqlCommand5.Parameters.Add(new SqlParameter("@Password", password));
                int usersCount = (int)sqlCommand5.ExecuteScalar();

                if (usersCount > 0)
                {
                    Console.WriteLine("Access granted!");
                }
                else
                {
                    Console.WriteLine("Access denied!");
                }
            }
        }
    }
}
