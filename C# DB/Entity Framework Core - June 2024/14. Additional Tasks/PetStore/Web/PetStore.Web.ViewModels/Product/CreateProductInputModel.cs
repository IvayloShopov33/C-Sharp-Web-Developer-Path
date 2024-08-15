using PetStore.Services.Mapping;
using System.ComponentModel.DataAnnotations;

using static PetStore.Common.ModelsValidationConstraints;

namespace PetStore.Web.ViewModels.Product
{
    public class CreateProductInputModel : IMapTo<PetStore.Data.Models.Product>
    {
        [Required(ErrorMessage = ProductNameIsRequired)]
        [MinLength(ProductNameMinLength, ErrorMessage = ProductNameMinLengthMessage)]
        [MaxLength(ProductNameMaxLength, ErrorMessage = ProductNameMaxLengthMessage)]
        public string Name { get; set; }

        [Required]
        [Range(typeof(decimal), ProductPriceMinValue, ProductPriceMaxValue)]
        public decimal Price { get; set; }

        [Required]
        public string ImageURL { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}