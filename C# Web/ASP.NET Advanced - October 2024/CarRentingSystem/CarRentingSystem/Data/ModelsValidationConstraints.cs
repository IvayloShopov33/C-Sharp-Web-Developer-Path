namespace CarRentingSystem.Data
{
    public class ModelsValidationConstraints
    {
        // Car
        public const byte CarMakeMinLength = 2;
        public const byte CarMakeMaxLength = 70;
        public const byte CarModelMinLength = 2;
        public const byte CarModelMaxLength = 80;
        public const byte CarDescriptionMinLength = 15;
        public const int CarYearMinValue = 1900;
        public const int CarYearMaxValue = 2060;

        // Category
        public const byte CategoryNameMinLength = 3;
        public const byte CategoryNameMaxLength = 100;

        // Dealer
        public const byte DealerNameMinLength = 2;
        public const byte DealerNameMaxLength = 50;
        public const byte DealerPhoneNumberMinLength = 6;
        public const byte DealerPhoneNumberMaxLength = 30;

        // User
        public const byte UserFullNameMinLength = 5;
        public const byte UserFullNameMaxLength = 120;
        public const byte UserPasswordMinLength = 6;
        public const byte UserPasswordMaxLength = 100;
    }
}