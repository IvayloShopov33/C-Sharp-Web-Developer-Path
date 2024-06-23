using Microsoft.Data.SqlClient;

namespace _07._Print_All_Minion_Names
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

                List<string> minionsNames = new List<string>();
                var allMinionsAvailable = new SqlCommand(
                    "SELECT [Name] FROM [Minions]", connection);
                using (var reader = allMinionsAvailable.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        minionsNames.Add(reader["Name"].ToString());
                    }
                }

                int rightMove = 0;
                int leftMove = 0;
                for (int i = 0; i < minionsNames.Count; i += 2)
                {
                    Console.WriteLine(minionsNames[rightMove]);

                    if (rightMove != minionsNames.Count - 1 - leftMove)
                    {
                        Console.WriteLine(minionsNames[minionsNames.Count - 1 - leftMove]);
                    }

                    rightMove++;
                    leftMove++;
                }
            }
        }
    }
}
