using Microsoft.Data.SqlClient;

namespace _05._Change_Town_Names_Casing
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

                string countryName = Console.ReadLine();
                var countryTownsUpdate = new SqlCommand(
                    @"UPDATE [Towns]
                        SET [Name] = UPPER([Name])
                        WHERE [CountryCode] = (SELECT c.[Id] FROM [Countries] AS c WHERE c.[Name] = @countryName)", connection);
                countryTownsUpdate.Parameters.AddWithValue("@countryName", countryName);
                int rowsAffected = countryTownsUpdate.ExecuteNonQuery();

                if (rowsAffected == 0)
                {
                    Console.WriteLine("No town names were affected.");
                }
                else
                {
                    Console.WriteLine($"{rowsAffected} town names were affected");
                    var changedTownsNames = new SqlCommand(
                        @"SELECT t.[Name]
                            FROM [Towns] as t
                            JOIN [Countries] AS c ON c.[Id] = t.[CountryCode]
                            WHERE c.[Name] = @countryName", connection);
                    changedTownsNames.Parameters.AddWithValue("@countryName", countryName);

                    List<string> newTownsNames = new List<string>();
                    using (var reader = changedTownsNames.ExecuteReader()) 
                    {
                        while (reader.Read())
                        {
                            newTownsNames.Add(reader["Name"].ToString());
                        }
                    }

                    Console.WriteLine($"[{string.Join(", ", newTownsNames)}]");
                }
            }
        }
    }
}
