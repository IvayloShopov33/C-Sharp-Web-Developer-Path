using System.ComponentModel.DataAnnotations;

using SeminarHub.Data.Models;

using static SeminarHub.Common.ModelsValidationConstraints;

namespace SeminarHub.Models.Seminar
{
    public class SeminarFormModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(SeminarTopicMaxLength, MinimumLength = SeminarTopicMinLength)]
        public string Topic { get; set; } = null!;

        [Required]
        [StringLength(SeminarLecturerMaxLength, MinimumLength = SeminarLecturerMinLength)]
        public string Lecturer { get; set; } = null!;

        [Required]
        [StringLength(SeminarDetailsMaxLength, MinimumLength = SeminarDetailsMinLength)]
        public string Details { get; set; } = null!;

        [Required]
        public string DateAndTime { get; set; } = DateTime.UtcNow.ToString(SeminarDateAndTimeDateFormat);

        [Range(SeminarDurationMinValue, SeminarDurationMaxValue)]
        public int? Duration { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public List<Category> Categories { get; set; } = new List<Category>();
    }
}