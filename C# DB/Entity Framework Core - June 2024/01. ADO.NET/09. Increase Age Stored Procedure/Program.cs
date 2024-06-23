using Microsoft.Data.SqlClient;

namespace _09._Increase_Age_Stored_Procedure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sqlConnectionString =
                "Server=localhost;Integrated Security=true;Database=MinionsDB;TrustServerCertificate=true";

            using (var connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();

                int minionId = int.Parse(Console.ReadLine());

                var storedProcedureUse = new SqlCommand(
                    "EXEC usp_GetOlder @id", connection);
                storedProcedureUse.Parameters.AddWithValue("@id", minionId);
                storedProcedureUse.ExecuteNonQuery();

                var storedProcedureResult = new SqlCommand(
                    "SELECT [Name], [Age] FROM [Minions] WHERE [Id] = @Id", connection);
                storedProcedureResult.Parameters.AddWithValue("@Id", minionId);

                using (var reader = storedProcedureResult.ExecuteReader()) 
                {
                    reader.Read();
                    Console.WriteLine($"{reader["Name"]} - {reader["Age"]} years old");
                }
            }
        }
    }
}
