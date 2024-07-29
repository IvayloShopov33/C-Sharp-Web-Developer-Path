namespace Trucks.Data
{
    public static class ModelsValidationConstraints
    {
        // Truck
        public const string TruckRegistrationNumberRegEx = @"^[A-Z]{2}\d{4}[A-Z]{2}$";
        public const byte TruckRegistrationNumberMaxValue = 8;
        public const byte TruckVinNumberMinValue = 17;
        public const byte TruckVinNumberMaxValue = 17;
        public const int TruckTankCapacityMinValue = 950;
        public const int TruckTankCapacityMaxValue = 1420;
        public const int TruckCargoCapacityMinValue = 5000;
        public const int TruckCargoCapacityMaxValue = 29000;
        public const byte TruckCategoryTypeMinValue = 0;
        public const byte TruckCategoryTypeMaxValue = 3;
        public const byte TruckMakeTypeMinValue = 0;
        public const byte TruckMakeTypeMaxValue = 4;

        // Client
        public const byte ClientNameMinLength = 3;
        public const byte ClientNameMaxLength = 40;
        public const byte ClientNationalityMinLength = 2;
        public const byte ClientNationalityMaxLength = 40;

        // Despatcher
        public const byte DespatcherNameMinLength = 2;
        public const byte DespatcherNameMaxLength = 40;
    }
}