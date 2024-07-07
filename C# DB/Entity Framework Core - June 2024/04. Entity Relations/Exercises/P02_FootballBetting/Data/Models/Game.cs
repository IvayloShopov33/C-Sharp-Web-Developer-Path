using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P02_FootballBetting.Data.Models
{
    public class Game
    {
        [Key]
        public int GameId { get; set; }

        [Required]
        public int HomeTeamId { get; set; }

        [InverseProperty("HomeGames")]
        public Team HomeTeam { get; set; }

        [Required]
        public int AwayTeamId { get; set; }

        [InverseProperty("AwayGames")]
        public Team AwayTeam { get; set; }

        [Required]
        public int HomeTeamGoals { get; set; }

        [Required]
        public int AwayTeamGoals { get; set; }

        [Required]
        public double HomeTeamBetRate { get; set; }

        [Required]
        public double AwayTeamBetRate { get; set; }

        [Required]
        public double DrawBetRate { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public string Result { get; set; }

        public ICollection<Bet> Bets { get; set; } = new HashSet<Bet>();

        public ICollection<PlayerStatistic> PlayersStatistics { get; set; } = new HashSet<PlayerStatistic>();
    }
}