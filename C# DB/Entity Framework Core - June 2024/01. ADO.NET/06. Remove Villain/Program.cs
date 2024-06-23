using Microsoft.Data.SqlClient;

namespace _06._Remove_Villain
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

                int villainIdInput = int.Parse(Console.ReadLine());

                var villainToDelete = new SqlCommand(
                    "SELECT [Name] FROM [Villains] WHERE [Id] = @villainId", connection);
                villainToDelete.Parameters.AddWithValue("@villainId", villainIdInput);

                if (villainToDelete.ExecuteScalar() == null)
                {
                    Console.WriteLine("No such villain was found.");
                    return;
                }

                string villainName = (string)villainToDelete.ExecuteScalar();

                var minionsToRelease = new SqlCommand(
                    @"DELETE FROM [MinionsVillains]
                        WHERE [VillainId] = @villainId", connection);
                minionsToRelease.Parameters.AddWithValue("@villainId", villainIdInput);
                int minionsCount = minionsToRelease.ExecuteNonQuery();

                var villainDelete = new SqlCommand(
                    @"DELETE FROM [Villains]
                        WHERE [Id] = @villainId", connection);
                villainDelete.Parameters.AddWithValue("@villainId", villainIdInput);
                villainDelete.ExecuteNonQuery();

                Console.WriteLine($"{villainName} was deleted.");
                Console.WriteLine($"{minionsCount} minions were released.");
            }
        }
    }
}
