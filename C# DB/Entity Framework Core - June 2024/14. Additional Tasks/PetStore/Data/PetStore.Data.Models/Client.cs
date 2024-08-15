using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static PetStore.Common.ModelsValidationConstraints;

namespace PetStore.Data.Models
{
    public class Client : ApplicationUser
    {
        [Required]
        [MaxLength(ClientNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(ClientNameMaxLength)]
        public string LastName { get; set; } = null!;

        [ForeignKey(nameof(Address))]
        public string AddressId { get; set; }

        public virtual Address Address { get; set; }

        [ForeignKey(nameof(ClientCard))]
        public string ClientCardId { get; set; }

        public virtual ClientCard ClientCard { get; set; }

        public virtual ICollection<CardInfo> PaymentCards { get; set; } = new HashSet<CardInfo>();

        public virtual ICollection<Pet> Pets { get; set; } = new HashSet<Pet>();

        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}