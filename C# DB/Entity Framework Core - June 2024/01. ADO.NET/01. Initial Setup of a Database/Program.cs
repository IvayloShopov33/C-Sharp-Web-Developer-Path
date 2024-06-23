using Microsoft.Data.SqlClient;

namespace _01._Initial_Setup_of_a_Database
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sqlConnectionString =
                "Server=localhost;Integrated Security=true;Database=master;TrustServerCertificate=true";

            using (var connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();
                var databaseCreation = new SqlCommand("CREATE DATABASE [MinionsDB]", connection);
                databaseCreation.ExecuteNonQuery();

                var databaseUse = new SqlCommand("USE [MinionsDB]", connection);
                databaseUse.ExecuteNonQuery();

                var tablesCreation = new SqlCommand(
                    "CREATE TABLE [Countries] ([Id] INT PRIMARY KEY IDENTITY, [Name] VARCHAR(50) NOT NULL) " +
                    "CREATE TABLE [Towns] ([Id] INT PRIMARY KEY IDENTITY, [Name] VARCHAR(50) NOT NULL, [CountryCode] INT REFERENCES [Countries]([Id]) NOT NULL) " +
                    "CREATE TABLE [Minions] ([Id] INT PRIMARY KEY IDENTITY, [Name] VARCHAR(50) NOT NULL," +
                    "[Age] INT NOT NULL, [TownId] INT REFERENCES [Towns]([Id]) NOT NULL)" +
                    "CREATE TABLE [EvilnessFactors] ([Id] INT PRIMARY KEY IDENTITY, [Name] VARCHAR(50) NOT NULL)" +
                    "CREATE TABLE [Villains] ([Id] INT PRIMARY KEY IDENTITY, [Name] VARCHAR(50) NOT NULL, [EvilnessFactorId] INT REFERENCES [EvilnessFactors]([Id]) NOT NULL)" +
                    "CREATE TABLE [MinionsVillains] ([MinionId] INT REFERENCES [Minions]([Id]), [VillainId] INT REFERENCES [Villains]([Id]), " +
                    "CONSTRAINT PK_MinionsVillains PRIMARY KEY ([MinionId], [VillainId]))", connection);

                tablesCreation.ExecuteNonQuery();

                var dataInsertedIntoCountriesTable = new SqlCommand(
                    "INSERT INTO [Countries]([Name]) VALUES ('Bulgaria'), ('Germany'), ('Russia'), ('Spain'), ('Italy')", connection);
                dataInsertedIntoCountriesTable.ExecuteNonQuery();

                var dataInsertedIntoTownsTable = new SqlCommand(
                    "INSERT INTO [Towns]([Name], [CountryCode]) VALUES ('Sofia', 1), ('Dortmund', 2), ('Moscow', 3), " +
                    "('Madrid', 4), ('Rome', 5)", connection);
                dataInsertedIntoTownsTable.ExecuteNonQuery();

                var dataInsertedIntoMinionsTable = new SqlCommand(
                    "INSERT INTO [Minions]([Name], [Age], [TownId]) VALUES ('Skibidi', 18, 1), ('Sui', 13, 2), " +
                    "('Rom', 10, 5), ('George', 23, 3), ('Opi', 19, 4)", connection);
                dataInsertedIntoMinionsTable.ExecuteNonQuery();

                var dataInsertedIntoEvilnessFactorsTable = new SqlCommand(
                    "INSERT INTO [EvilnessFactors]([Name]) VALUES ('super good'), ('good'), ('bad'), " +
                    "('evil'), ('super evil')", connection);
                dataInsertedIntoEvilnessFactorsTable.ExecuteNonQuery();

                var dataInsertedIntoVillainsTable = new SqlCommand(
                    "INSERT INTO [Villains]([Name], [EvilnessFactorId]) VALUES ('Ivo', 1), ('Gru', 2), ('Teo', 3), " +
                    "('Sto', 5), ('Pro', 4)", connection);
                dataInsertedIntoVillainsTable.ExecuteNonQuery();

                var dataInsertedIntoMinionsVillainsTable = new SqlCommand(
                    "INSERT INTO [MinionsVillains]([MinionId], [VillainId]) VALUES (1, 1), (2, 2), (3, 3), " +
                    "(4, 4), (5, 5)", connection);
                dataInsertedIntoMinionsVillainsTable.ExecuteNonQuery();
            }
        }
    }
}