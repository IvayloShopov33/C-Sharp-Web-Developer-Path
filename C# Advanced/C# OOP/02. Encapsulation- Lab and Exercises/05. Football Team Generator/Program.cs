namespace FootballTeamGenerator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();
            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split(';');
                string command = tokens[0];
                string teamName = tokens[1];

                try
                {
                    switch (command)
                    {
                        case "Team":
                            AddTeam(teams, teamName);
                            break;
                        case "Add":
                            AddPlayer(teams, tokens, teamName);
                            break;
                        case "Remove":
                            RemovePlayer(teams, tokens, teamName);
                            break;
                        case "Rating":
                            PrintRating(teams, teamName);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void AddTeam(List<Team> teams, string teamName)
        {
            Team team = new Team(teamName);
            teams.Add(team);
        }

        public static void AddPlayer(List<Team> teams, string[] tokens, string teamName)
        {
            string playerName = tokens[2];
            int playerEndurance = int.Parse(tokens[3]);
            int playerSprint = int.Parse(tokens[4]);
            int playerDribble = int.Parse(tokens[5]);
            int playerPassing = int.Parse(tokens[6]);
            int playerShooting = int.Parse(tokens[7]);

            Team selectedTeam = teams.FirstOrDefault(x => x.Name == teamName);
            if (selectedTeam == null)
            {
                throw new ArgumentException($"Team {teamName} does not exist.");
            }

            Player player = new Player(playerName, playerEndurance, playerSprint, playerDribble, playerPassing, playerShooting);
            selectedTeam.AddPlayer(player);
        }

        public static void RemovePlayer(List<Team> teams, string[] tokens, string teamName)
        {
            Team chosenTeam = teams.FirstOrDefault(x => x.Name == teamName);
            if (chosenTeam == null)
            {
                throw new ArgumentException($"Team {teamName} does not exist.");
            }

            string nameOfPlayer = tokens[2];
            chosenTeam.RemovePlayer(nameOfPlayer);
        }

        public static void PrintRating(List<Team> teams, string teamName)
        {
            Team teamToGetRating = teams.FirstOrDefault(x => x.Name == teamName);
            if (teamToGetRating == null)
            {
                throw new ArgumentException($"Team {teamName} does not exist.");
            }

            Console.WriteLine($"{teamToGetRating.Name} - {teamToGetRating.Rating}");
        }
    }
}