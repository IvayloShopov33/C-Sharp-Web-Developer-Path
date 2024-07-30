namespace P03_SalesDatabase.Data
{
    public static class ModelsValidationConstraints
    {
        // Product
        public const byte ProductNameMaxLength = 50;

        // Customer
        public const byte CustomerNameMaxLength = 100;
        public const byte CustomerEmailMaxLength = 80;

        // Store
        public const byte StoreNameMaxLength = 80;
    }
}