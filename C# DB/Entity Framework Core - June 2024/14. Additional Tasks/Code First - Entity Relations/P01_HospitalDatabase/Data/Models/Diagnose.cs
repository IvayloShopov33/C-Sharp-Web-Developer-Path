﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static P01_HospitalDatabase.Data.ModelsValidationConstraints;

namespace P01_HospitalDatabase.Data.Models
{
    public class Diagnose
    {
        [Key]
        public int DiagnoseId { get; set; }

        [Required]
        [MaxLength(DiagnoseNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(DiagnoseCommentsMaxLength)]
        public string Comments { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Patient))]
        public int PatientId { get; set; }

        public virtual Patient Patient { get; set; } = null!;
    }
}