namespace NetPay.Data
{
    public static class ModelsValidationConstraints
    {
        // Household
        public const byte HouseholdContactPersonMinLength = 5;
        public const byte HouseholdContactPersonMaxLength = 50;
        public const byte HouseholdEmailMinLength = 6;
        public const byte HouseholdEmailMaxLength = 80;
        public const byte HouseholdPhoneNumberMaxLength = 15;
        public const string HouseholdPhoneNumberRegEx = @"^\+\d{3}/\d{3}-\d{6}$";

        // Expense
        public const byte ExpenseNameMinLength = 5;
        public const byte ExpenseNameMaxLength = 50;
        public const string ExpenseAmountMinValue = "0.01";
        public const string ExpenseAmountMaxValue = "100000";
        public const string ExpensePaymentStatusRegex = @"^(Paid|Unpaid|Overdue|Expired)$";

        // Service
        public const byte ServiceNameMinLength = 5;
        public const byte ServiceNameMaxLength = 30;

        // Supplier
        public const byte SupplierNameMinLength = 3;
        public const byte SupplierNameMaxLength = 60;
    }
}