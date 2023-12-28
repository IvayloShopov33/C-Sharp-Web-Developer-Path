using Handball.Models.Contracts;
using Handball.Models.Players;
using Handball.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Handball.Models.Teams
{
    public class Team : ITeam
    {
        private string name;
        private List<IPlayer> players;

        public Team(string name)
        {
            this.Name = name;
            this.PointsEarned = 0;
            this.players = new List<IPlayer>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.TeamNameNull);
                }

                this.name = value;
            }
        }

        public int PointsEarned { get; private set; }

        public double OverallRating
        {
            get
            {
                if (this.Players.Count == 0)
                {
                    return 0;
                }
                else
                {
                    return Math.Round(this.Players.Average(x => x.Rating), 2);
                }
            }
        }

        public IReadOnlyCollection<IPlayer> Players => this.players.AsReadOnly();

        public void Draw()
        {
            this.PointsEarned++;

            IPlayer goalkeeper = this.players.FirstOrDefault(x => x.GetType().Name == nameof(Goalkeeper));
            goalkeeper.IncreaseRating();
        }

        public void Lose()
        {
            foreach (IPlayer player in this.Players)
            {
                player.DecreaseRating();
            }
        }

        public void SignContract(IPlayer player)
        {
            this.players.Add(player);
        }

        public void Win()
        {
            this.PointsEarned += 3;

            foreach (IPlayer player in this.Players)
            {
                player.IncreaseRating();
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Team: {this.Name} Points: {this.PointsEarned}");
            sb.AppendLine($"--Overall rating: {this.OverallRating}");

            if (this.Players.Count == 0)
            {
                sb.AppendLine("--Players: none");
            }
            else
            {
                sb.AppendLine($"--Players: {string.Join(", ", this.Players.Select(x => x.Name))}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
