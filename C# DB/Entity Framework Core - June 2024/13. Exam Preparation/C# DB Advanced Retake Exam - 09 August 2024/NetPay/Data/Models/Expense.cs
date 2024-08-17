using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using NetPay.Data.Models.Enums;

using static NetPay.Data.ModelsValidationConstraints;

namespace NetPay.Data.Models
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ExpenseNameMaxLength)]
        public string ExpenseName { get; set; } = null!;

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        public PaymentStatus PaymentStatus { get; set; }

        [Required]
        [ForeignKey(nameof(Household))]
        public int HouseholdId { get; set; }

        public virtual Household Household { get; set; }

        [Required]
        [ForeignKey(nameof(Service))]
        public int ServiceId { get; set; }

        public virtual Service Service { get; set; }
    }
}