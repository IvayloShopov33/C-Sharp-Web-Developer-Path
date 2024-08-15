using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using PetStore.Data.Common.Models;

using static PetStore.Common.ModelsValidationConstraints;

namespace PetStore.Data.Models
{
    public class Pet : BaseDeletableModel<string>
    {
        public Pet()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [MaxLength(PetNameMaxLength)]
        public string Name { get; set; }

        [Required]
        public byte Age { get; set; }

        [Required]
        public string Breed { get; set; } = null!;

        [Required]
        public string ImageURL { get; set; }

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Price { get; set; }

        [Required]
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        [ForeignKey(nameof(Owner))]
        public string ClientId { get; set; }

        public virtual Client Owner { get; set; }

        [Required]
        [ForeignKey(nameof(Store))]
        public string StoreId { get; set; } = null!;

        public virtual Store Store { get; set; }
    }
}