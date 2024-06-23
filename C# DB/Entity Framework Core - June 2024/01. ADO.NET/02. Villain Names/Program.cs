using Microsoft.Data.SqlClient;

namespace _02._Villain_Names
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

                var villainNames = new SqlCommand(
                    @"SELECT v.[Name], COUNT(mv.[MinionId]) AS [MinionsCount]
	                    FROM [Villains] v
	                    JOIN [MinionsVillains] mv ON mv.[VillainId] = v.[Id]
	                    GROUP BY v.[Name]
	                    HAVING COUNT(mv.[MinionId]) > 3
	                    ORDER BY [MinionsCount] DESC", connection);
                var reader = villainNames.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"{reader["Name"]} => {reader["MinionsCount"]}");
                }
            }
        }
    }
}
