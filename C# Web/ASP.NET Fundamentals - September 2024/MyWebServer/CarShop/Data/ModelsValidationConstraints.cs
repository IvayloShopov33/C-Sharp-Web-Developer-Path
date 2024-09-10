namespace CarShop.Data
{
    public static class ModelsValidationConstraints
    {
        // User
        public const byte UserIdMaxLength = 40;
        public const byte UserNameMaxLength = 20;
        public const byte UserNameMinLength = 4;
        public const byte UserPasswordMaxLength = 20;
        public const byte UserPasswordMinLength = 5;
        public const string UserTypeClient = "Client";
        public const string UserTypeMechanic = "Mechanic";

        // Car
        public const byte CarIdMaxLength = 40;
        public const byte CarModelMaxLength = 20;
        public const byte CarModelMinLength = 5;
        public const int CarYearMinValue = 1900;
        public const byte CarPlateNumberMaxLength = 8;
        public const byte CarOwnerIdMaxLength = 40;
        public const string CarPlateNumberRegEx = @"[A-Z]{2}[0-9]{4}[A-Z]{2}";

        // Issue
        public const byte IssueIdMaxLength = 40;
        public const byte IssueDescriptionMinLength = 5;
    }
}