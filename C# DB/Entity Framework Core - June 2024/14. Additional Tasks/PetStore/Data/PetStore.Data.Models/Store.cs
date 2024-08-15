using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using PetStore.Data.Common.Models;

using static PetStore.Common.ModelsValidationConstraints;

namespace PetStore.Data.Models
{
    public class Store : BaseDeletableModel<string>
    {
        public Store() 
        { 
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        [MaxLength(StoreNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(StoreDescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Address))]
        public string AddressId { get; set; } = null!;

        public virtual Address Address { get; set; }

        public virtual ICollection<Pet> Pets { get; set; } = new HashSet<Pet>();

        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();

        public virtual ICollection<Service> Services { get; set; } = new HashSet<Service>();
    }
}