using System.ComponentModel.DataAnnotations;

namespace Invoices.DataProcessor.ImportDto
{
    public class ProductInputJsonModel
    {
        [Required]
        [MinLength(9)]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [Range(5.00, 1000.00)]
        public decimal Price { get; set; }

        [Required]
        [Range(0, 4)]
        public int CategoryType { get; set; }

        [Required]
        public int[] Clients { get; set; }
    }
}