using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using PetStore.Data.Common.Models;

using static PetStore.Common.ModelsValidationConstraints;

namespace PetStore.Data.Models
{
    public class CardInfo : BaseDeletableModel<string>
    {
        public CardInfo()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        [StringLength(CardInfoNumberMaxLength)]
        public string CardNumber { get; set; } = null!;

        [Required]
        [MaxLength(CardInfoExpirationDateMaxLength)]
        public string ExpirationDate { get; set; } = null!;

        [Required]
        [MaxLength(CardInfoHolderMaxLength)]
        public string CardHolder { get; set; } = null!;

        [Required]
        [MaxLength(CardInfoCVCMaxLength)]
        public string CVC { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Client))]
        public string ClientId { get; set; }

        public virtual Client Client { get; set; }
    }
}