namespace FootballTeamGenerator
{
    public class Team
    {
        private const string NameArgumentExceptionMessage = "A name should not be empty.";
        private const string RemovePlayerArgumentExceptionMessage = "Player {0} is not in {1} team.";

        private List<Player> players;
        private string teamName;

        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }

        public string Name
        {
            get
            {
                return this.teamName;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(NameArgumentExceptionMessage);
                }

                this.teamName = value;
            }
        }

        public int Rating
        {
            get
            {
                if (this.players.Count > 0)
                {
                    return (int)Math.Round(this.players.Select(x => x.AverageSkillLevel).Average());
                }

                return 0;
            }
        }

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            Player player = this.players.FirstOrDefault(x => x.Name == playerName);
            if (player == null)
            {
                throw new ArgumentException(string.Format(RemovePlayerArgumentExceptionMessage, playerName, this.Name));
            }

            this.players.Remove(player);
        }
    }
}
