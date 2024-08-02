namespace Artillery.Data
{
    public static class ModelsValidationConstraints
    {
        // Country
        public const byte CountryNameMinLength = 4;
        public const byte CountryNameMaxLength = 60;
        public const int CountryArmySizeMinValue = 50_000;
        public const int CountryArmySizeMaxValue = 10_000_000;

        // Manufacturer
        public const byte ManufacturerNameMinLength = 4;
        public const byte ManufacturerNameMaxLength = 40;
        public const byte ManufacturerFoundedMinLength = 10;
        public const byte ManufacturerFoundedMaxLength = 100;

        // Shell
        public const double ShellWeightMinValue = 2;
        public const double ShellWeightMaxValue = 1_680;
        public const byte ShellCaliberMinLength = 4;
        public const byte ShellCaliberMaxLength = 30;

        // Gun
        public const int GunWeightMinValue = 100;
        public const int GunWeightMaxValue = 1_350_000;
        public const double GunBarrelLengthMinValue = 2.00;
        public const double GunBarrelLengthMaxValue = 35.00;
        public const int GunRangeMinValue = 1;
        public const int GunRangeMaxValue = 100_000;
        public const byte GunTypeMinValue = 0;
        public const byte GunTypeMaxValue = 5;
    }
}