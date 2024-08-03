namespace TravelAgency.Data
{
    public static class ModelsValidationConstraints
    {
        // Customer
        public const byte CustomerFullNameMinLength = 4;
        public const byte CustomerFullNameMaxLength = 60;
        public const byte CustomerEmailMinLength = 6;
        public const byte CustomerEmailMaxLength = 50;
        public const byte CustomerPhoneNumberMaxLength = 13;
        public const string CustomerPhoneNumberRegEx = @"^\+\d{12}$";

        // Guide
        public const byte GuideFullNameMinLength = 4;
        public const byte GuideFullNameMaxLength = 60;
        public const byte GuideLanguageMinValue = 0;
        public const byte GuideLanguageMaxValue = 4;

        // TourPackage
        public const byte TourPackageNameMinLength = 2;
        public const byte TourPackageNameMaxLength = 40;
        public const byte TourPackageDescriptionMaxLength = 200;
        public const decimal TourPackagePriceMinValue = 0;
    }
}