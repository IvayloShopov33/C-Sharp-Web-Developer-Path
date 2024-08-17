﻿using System.ComponentModel.DataAnnotations;

using static NetPay.Data.ModelsValidationConstraints;

namespace NetPay.Data.Models
{
    public class Supplier
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(SupplierNameMaxLength)]
        public string SupplierName { get; set; } = null!;

        public virtual ICollection<SupplierService> SuppliersServices { get; set; } = new HashSet<SupplierService>();
    }
}