using Handball.Core.Contracts;
using Handball.Models.Contracts;
using Handball.Models.Players;
using Handball.Models.Teams;
using Handball.Repositories;
using Handball.Repositories.Contracts;
using Handball.Utilities.Messages;
using System.Linq;
using System.Text;

namespace Handball.Core
{
    public class Controller : IController
    {
        private IRepository<IPlayer> playerRepository;
        private IRepository<ITeam> teamRepository;

        public Controller()
        {
            this.playerRepository = new PlayerRepository();
            this.teamRepository = new TeamRepository();
        }

        public string LeagueStandings()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***League Standings***");

            foreach (ITeam team in this.teamRepository.Models.OrderByDescending(x => x.PointsEarned).ThenByDescending(x => x.OverallRating).ThenBy(x => x.Name))
            {
                sb.AppendLine(team.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string NewContract(string playerName, string teamName)
        {
            if (!this.playerRepository.ExistsModel(playerName))
            {
                return string.Format(OutputMessages.PlayerNotExisting, playerName, this.playerRepository.GetType().Name);
            }

            if (!this.teamRepository.ExistsModel(teamName))
            {
                return string.Format(OutputMessages.TeamNotExisting, teamName, this.teamRepository.GetType().Name);
            }

            IPlayer player = this.playerRepository.GetModel(playerName);
            ITeam team = this.teamRepository.GetModel(teamName);

            if (player.Team != null)
            {
                return string.Format(OutputMessages.PlayerAlreadySignedContract, player.Name, player.Team);
            }

            player.JoinTeam(teamName);
            team.SignContract(player);

            return string.Format(OutputMessages.SignContract, player.Name, team.Name);
        }

        public string NewGame(string firstTeamName, string secondTeamName)
        {
            ITeam firstTeam = this.teamRepository.GetModel(firstTeamName);
            ITeam secondTeam = this.teamRepository.GetModel(secondTeamName);

            if (firstTeam.OverallRating > secondTeam.OverallRating)
            {
                firstTeam.Win();
                secondTeam.Lose();

                return string.Format(OutputMessages.GameHasWinner, firstTeam.Name, secondTeam.Name);
            }
            else if (secondTeam.OverallRating > firstTeam.OverallRating)
            {
                secondTeam.Win();
                firstTeam.Lose();

                return string.Format(OutputMessages.GameHasWinner, secondTeam.Name, firstTeam.Name);
            }
            else
            {
                firstTeam.Draw();
                secondTeam.Draw();

                return string.Format(OutputMessages.GameIsDraw, firstTeam.Name, secondTeam.Name);
            }
        }

        public string NewPlayer(string typeName, string name)
        {
            if (typeName != nameof(Goalkeeper) && typeName != nameof(CenterBack) && typeName != nameof(ForwardWing))
            {
                return string.Format(OutputMessages.InvalidTypeOfPosition, typeName);
            }

            if (this.playerRepository.ExistsModel(name))
            {
                IPlayer player = this.playerRepository.GetModel(name);

                return string.Format(OutputMessages.PlayerIsAlreadyAdded, player.Name, this.playerRepository.GetType().Name, player.GetType().Name);
            }

            IPlayer newPlayer = null;

            if (typeName == nameof(Goalkeeper))
            {
                newPlayer = new Goalkeeper(name);
            }
            else if (typeName == nameof(CenterBack))
            {
                newPlayer = new CenterBack(name);
            }
            else
            {
                newPlayer = new ForwardWing(name);
            }

            this.playerRepository.AddModel(newPlayer);

            return string.Format(OutputMessages.PlayerAddedSuccessfully, newPlayer.Name);
        }

        public string NewTeam(string name)
        {
            if (this.teamRepository.ExistsModel(name))
            {
                return string.Format(OutputMessages.TeamAlreadyExists, this.teamRepository.GetModel(name).Name, this.teamRepository.GetType().Name);
            }

            ITeam team = new Team(name);
            this.teamRepository.AddModel(team);

            return string.Format(OutputMessages.TeamSuccessfullyAdded, this.teamRepository.GetModel(name).Name, this.teamRepository.GetType().Name);
        }

        public string PlayerStatistics(string teamName)
        {
            StringBuilder sb = new StringBuilder();
            ITeam team = this.teamRepository.GetModel(teamName);
            sb.AppendLine($"***{team.Name}***");

            foreach (IPlayer player in team.Players.OrderByDescending(x => x.Rating).ThenBy(x => x.Name))
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
