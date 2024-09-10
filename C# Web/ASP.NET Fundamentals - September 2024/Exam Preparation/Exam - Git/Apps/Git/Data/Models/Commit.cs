using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static Git.Data.ModelsValidationConstraints;

namespace Git.Data.Models
{
    public class Commit
    {
        [Key]
        [MaxLength(IdMaxLength)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        [MaxLength(IdMaxLength)]
        [ForeignKey(nameof(Creator))]
        public string CreatorId { get; set; } = null!;

        public virtual User Creator { get; set; }

        [Required]
        [MaxLength(IdMaxLength)]
        [ForeignKey(nameof(Repository))]
        public string RepositoryId { get; set; } = null!;

        public virtual Repository Repository { get; set; }
    }
}