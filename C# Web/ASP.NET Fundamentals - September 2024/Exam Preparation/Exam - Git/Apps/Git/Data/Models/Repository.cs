using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static Git.Data.ModelsValidationConstraints;

namespace Git.Data.Models
{
    public class Repository
    {
        [Key]
        [MaxLength(IdMaxLength)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(RepositoryNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public bool IsPublic { get; set; }

        [Required]
        [MaxLength(IdMaxLength)]
        [ForeignKey(nameof(Owner))]
        public string OwnerId { get; set; } = null!;

        public virtual User Owner { get; set; }

        public virtual ICollection<Commit> Commits { get; set; } = new HashSet<Commit>();
    }
}