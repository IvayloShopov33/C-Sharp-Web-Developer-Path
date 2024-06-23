using Microsoft.Data.SqlClient;

namespace _08._Increase_Minion_Age
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

                int[] minionIds = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                foreach (int minionId in minionIds)
                {
                    var minionsAgeUpdate = new SqlCommand(
                        @"UPDATE [Minions]
                            SET [Name] = UPPER(LEFT([Name], 1)) + SUBSTRING([Name], 2, LEN([Name])), [Age] += 1
                            WHERE [Id] = @Id", connection);
                    minionsAgeUpdate.Parameters.AddWithValue("@Id", minionId);
                    minionsAgeUpdate.ExecuteNonQuery();
                }

                var allAvailableMinions = new SqlCommand(
                    "SELECT [Name], [Age] FROM [Minions]", connection);
                using (var reader = allAvailableMinions.ExecuteReader())
                {
                    while (reader.Read()) 
                    {
                        Console.WriteLine($"{reader["Name"]} {reader["Age"]}");
                    }
                }
            }
        }
    }
}
