namespace PetStore.Common
{
    public static class ModelsValidationConstraints
    {
        // Messages
        public const string ProductNameIsRequired = "Product name is required.";
        public const string ProductNameMinLengthMessage = "Product name must be at least 5 characters long.";
        public const string ProductNameMaxLengthMessage = "Product name must be no more than 70 characters long.";


        // Pet
        public const byte PetNameMinLength = 3;
        public const byte PetNameMaxLength = 50;

        // Product
        public const byte ProductNameMinLength = 5;
        public const byte ProductNameMaxLength = 70;
        public const string ProductPriceMinValue = "0";
        public const string ProductPriceMaxValue = "79228162514264337593543950335";

        // Category
        public const byte CategoryNameMinLength = 5;
        public const byte CategoryNameMaxLength = 60;

        // Store
        public const byte StoreNameMinLength = 4;
        public const byte StoreNameMaxLength = 80;
        public const byte StoreDescriptionMinLength = 16;
        public const byte StoreDescriptionMaxLength = 255;

        // Address
        public const byte AddressTextMinLength = 8;
        public const byte AddressTextMaxLength = 128;
        public const byte AddressTownNameMinLength = 4;
        public const byte AddressTownNameMaxLength = 80;

        // Client
        public const byte ClientNameMinLength = 3;
        public const byte ClientNameMaxLength = 50;

        // CardInfo
        public const byte CardInfoNumberMinLength = 8;
        public const byte CardInfoNumberMaxLength = 19;
        public const byte CardInfoExpirationDateMaxLength = 5;
        public const byte CardInfoHolderMinLength = 5;
        public const byte CardInfoHolderMaxLength = 100;
        public const byte CardInfoCVCMaxLength = 4;

        // ClientCard
        public const byte ClientCardNumberMinLength = 5;
        public const byte ClientCardNumberMaxLength = 30;

        // Service
        public const byte ServiceNameMinLength = 4;
        public const byte ServiceNameMaxLength = 80;
        public const byte ServiceDescriptionMinLength = 16;
        public const byte ServiceDescriptionMaxLength = 255;
    }
}