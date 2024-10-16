using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.AspNetCore.Identity;

namespace GameZone.Data.Models
{
    public class GamerGame
    {
        [ForeignKey(nameof(Gamer))]
        public string GamerId { get; set; } = null!;

        public virtual IdentityUser Gamer { get; set; }

        [ForeignKey(nameof(Game))]
        public int GameId { get; set; }

        public virtual Game Game { get; set; }
    }
}
