using System.ComponentModel.DataAnnotations;

using static Trucks.Data.ModelsValidationConstraints;

namespace Trucks.DataProcessor.ImportDto
{
    public class ClientInputJsonModel
    {
        [Required]
        [MinLength(ClientNameMinLength)]
        [MaxLength(ClientNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MinLength(ClientNationalityMinLength)]
        [MaxLength(ClientNationalityMaxLength)]
        public string Nationality { get; set; } = null!;

        [Required]
        public string Type { get; set; } = null!;

        [Required]
        public int[] Trucks { get; set; } = null!;
    }
}