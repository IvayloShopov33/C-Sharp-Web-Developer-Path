using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using PetStore.Data.Common.Models;

using static PetStore.Common.ModelsValidationConstraints;

namespace PetStore.Data.Models
{
    public class Service : BaseDeletableModel<string>
    {
        public Service()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        [StringLength(ServiceNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(ServiceDescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Price { get; set; }

        public virtual ICollection<Store> Stores { get; set; } = new HashSet<Store>();

        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}