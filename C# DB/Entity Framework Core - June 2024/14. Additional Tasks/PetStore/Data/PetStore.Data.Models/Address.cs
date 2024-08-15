using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using PetStore.Data.Common.Models;

using static PetStore.Common.ModelsValidationConstraints;

namespace PetStore.Data.Models
{
    public class Address : BaseDeletableModel<string>
    {
        public Address()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        [MaxLength(AddressTextMaxLength)]
        public string Text { get; set; } = null!;

        [Required]
        [MaxLength(AddressTownNameMaxLength)]
        public string TownName { get; set; } = null!;

        public virtual ICollection<Client> Clients { get; set; } = new HashSet<Client>();
    }
}