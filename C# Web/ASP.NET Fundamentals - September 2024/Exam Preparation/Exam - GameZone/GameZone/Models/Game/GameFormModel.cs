using System.ComponentModel.DataAnnotations;

using GameZone.Data.Models;

using static GameZone.Constants.ModelsValidationConstants;

namespace GameZone.Models.Game
{
    public class GameFormModel
    {
        [Required]
        [StringLength(GameTitleMaxLength, MinimumLength = GameTitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(GameDescriptionMaxLength, MinimumLength = GameDescriptionMinLength)]
        public string Description { get; set; } = null!;

        public string? ImageUrl { get; set; }

        [Required]
        public string ReleasedOn { get; set; } = DateTime.UtcNow.ToString(GameReleasedOnDateFormat);

        [Required]
        public int GenreId { get; set; }

        public List<Genre> Genres { get; set; } = new List<Genre>();
    }
}
