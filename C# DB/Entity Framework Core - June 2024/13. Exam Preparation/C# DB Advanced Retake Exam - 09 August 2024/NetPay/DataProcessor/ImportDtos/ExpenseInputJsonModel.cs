using System.ComponentModel.DataAnnotations;

using static NetPay.Data.ModelsValidationConstraints;

namespace NetPay.DataProcessor.ImportDtos
{
    public class ExpenseInputJsonModel
    {
        [Required]
        [StringLength(ExpenseNameMaxLength, MinimumLength = ExpenseNameMinLength)]
        public string ExpenseName { get; set; } = null!;

        [Required]
        [Range(typeof(decimal), ExpenseAmountMinValue, ExpenseAmountMaxValue)]
        public decimal Amount { get; set; }

        [Required]
        public string DueDate { get; set; } = null!;

        [Required]
        [RegularExpression(ExpensePaymentStatusRegex)]
        public string PaymentStatus { get; set; } = null!;

        [Required]
        public int HouseholdId { get; set; }

        [Required]
        public int ServiceId { get; set; }
    }
}