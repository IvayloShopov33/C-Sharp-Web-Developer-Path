using Microsoft.Data.SqlClient;
namespace _04._Add_Minion
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

                string[] minionDetails = Console.ReadLine().Split().Skip(1).ToArray();
                string minionName = minionDetails[0];
                int minionAge = int.Parse(minionDetails[1]);
                string minionTown = minionDetails[2];

                string villainName = Console.ReadLine().Split()[1];

                var villainIdCommand = new SqlCommand("SELECT [Id] FROM [Villains] WHERE [Name] = @Name", connection);
                villainIdCommand.Parameters.AddWithValue("@Name", villainName);

                if (villainIdCommand.ExecuteScalar() == null)
                {
                    var newVillainInsertion = new SqlCommand(
                        "INSERT INTO [Villains] ([Name], [EvilnessFactorId])  VALUES (@villainName, 4)", connection);
                    newVillainInsertion.Parameters.AddWithValue("@villainName", villainName);
                    newVillainInsertion.ExecuteNonQuery();
                    Console.WriteLine($"Villain {villainName} was added to the database.");
                }

                int villainId = (int)villainIdCommand.ExecuteScalar();

                var minionTownIdCommand = new SqlCommand(
                    "SELECT [Id] FROM [Towns] WHERE [Name] = @townName", connection);
                minionTownIdCommand.Parameters.AddWithValue("@townName", minionTown);
                if (minionTownIdCommand.ExecuteScalar() == null)
                {
                    var newTownInsertion = new SqlCommand(
                        "INSERT INTO [Towns] ([Name]) VALUES (@townName)", connection);
                    newTownInsertion.Parameters.AddWithValue("@townName", minionTown);
                    newTownInsertion.ExecuteNonQuery();
                    Console.WriteLine($"Town {minionTown} was added to the database.");
                }

                var minionIdCommand = new SqlCommand("SELECT [Id] FROM [Minions] WHERE [Name] = @Name", connection);
                minionIdCommand.Parameters.AddWithValue("@Name", minionName);
                int minionId = 0;

                if (minionIdCommand.ExecuteScalar() == null)
                {
                    var newMinionInsertion = new SqlCommand(
                        "INSERT INTO [Minions] ([Name], [Age], [TownId]) VALUES (@nam, @age, @townId)", connection);
                    newMinionInsertion.Parameters.AddWithValue("@nam", minionName);
                    newMinionInsertion.Parameters.AddWithValue("@age", minionAge);
                    newMinionInsertion.Parameters.AddWithValue("@townId", minionTown);
                    newMinionInsertion.ExecuteNonQuery();
                }

                minionId = (int)minionIdCommand.ExecuteScalar();

                var villainMinionConnection = new SqlCommand(
                    "INSERT INTO [MinionsVillains] ([MinionId], [VillainId]) VALUES (@minionId, @villainId)", connection);
                villainMinionConnection.Parameters.AddWithValue("@villainId", villainId);
                villainMinionConnection.Parameters.AddWithValue("@minionId", minionId);
                villainMinionConnection.ExecuteNonQuery();
                Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
            }
        }
    }
}