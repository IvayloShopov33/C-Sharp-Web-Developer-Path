using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using PetStore.Data.Common.Models;

using static PetStore.Common.ModelsValidationConstraints;

namespace PetStore.Data.Models
{
    public class Category : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(CategoryNameMaxLength)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Pet> Pets { get; set; } = new HashSet<Pet>();

        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}