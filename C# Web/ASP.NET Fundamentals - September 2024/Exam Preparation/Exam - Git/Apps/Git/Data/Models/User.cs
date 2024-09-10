using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using static Git.Data.ModelsValidationConstraints;

namespace Git.Data.Models
{
    public class User
    {
        [Key]
        [MaxLength(IdMaxLength)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(UsernameMaxLength)]
        public string Username { get; set; } = null!;

        [Required]
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;

        public virtual ICollection<Repository> Repositories { get; set; } = new HashSet<Repository>();

        public virtual ICollection<Commit> Commits { get; set; } = new HashSet<Commit>();
    }
}