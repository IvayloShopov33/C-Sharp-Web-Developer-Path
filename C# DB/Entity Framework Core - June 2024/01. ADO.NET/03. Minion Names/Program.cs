using Microsoft.Data.SqlClient;

namespace _03._Minion_Names
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
                int villainId = int.Parse(Console.ReadLine());

                var villainName = new SqlCommand(
                    "SELECT Name FROM Villains WHERE Id = @Id", connection);
                villainName.Parameters.AddWithValue("@Id", villainId);

                if (villainName.ExecuteScalar() == null)
                {
                    Console.WriteLine($"No villain with ID {villainId} exists in the database.");
                    return;
                }
                else
                {
                    Console.WriteLine($"Villain: {villainName.ExecuteScalar()}");
                }

                var villainMinions = new SqlCommand(
                    @"SELECT ROW_NUMBER() OVER (ORDER BY m.[Name]) as [RowNum],
                                         m.[Name], 
                                         m.[Age]
                                    FROM [MinionsVillains] AS mv
                                    JOIN [Minions] As m ON mv.[MinionId] = m.[Id]
                                    WHERE mv.[VillainId] = @Id
                                    ORDER BY m.[Name]", connection);
                villainMinions.Parameters.AddWithValue("@Id", villainId);
                using (var reader = villainMinions.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        Console.WriteLine("(no minions)");
                    }
                    else
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader["RowNum"]}. {reader["Name"]} {reader["Age"]}");
                        }
                    }
                }               
            }
        }
    }
}
