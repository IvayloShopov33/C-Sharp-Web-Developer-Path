﻿using System.ComponentModel.DataAnnotations;

using static Trucks.Data.ModelsValidationConstraints;

namespace Trucks.Data.Models
{
    public class Despatcher
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(DespatcherNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        public string Position { get; set; } = null!;

        public virtual ICollection<Truck> Trucks { get; set; } = new HashSet<Truck>();
    }
}