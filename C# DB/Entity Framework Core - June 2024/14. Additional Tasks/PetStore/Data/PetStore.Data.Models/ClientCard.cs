using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using PetStore.Data.Common.Models;

using static PetStore.Common.ModelsValidationConstraints;

namespace PetStore.Data.Models
{
    public class ClientCard : BaseDeletableModel<string>
    {
        public ClientCard()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        [MaxLength(ClientCardNumberMaxLength)]
        public string CardNumber { get; set; } = null!;

        [Required]
        public DateTime ExpirationDate { get; set; }

        [Required]
        public int Discount { get; set; }

        [Required]
        [ForeignKey(nameof(Client))]
        public string ClientId { get; set; } = null!;

        public virtual Client Client { get; set; }
    }
}