﻿using System.ComponentModel.DataAnnotations;

using static Medicines.Data.ModelsValidationConstraints;

namespace Medicines.Data.Models
{
    public class Pharmacy
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(PharmacyNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        public bool IsNonStop { get; set; }

        public virtual ICollection<Medicine> Medicines { get; set; } = new HashSet<Medicine>();
    }
}