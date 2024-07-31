namespace Footballers.Data
{
    public static class ModelsValidationConstraints
    {
        // Footballer
        public const byte FootballerNameMinLength = 2;
        public const byte FootballerNameMaxLength = 40;
        public const byte FootballerPositionTypeMinValue = 0;
        public const byte FootballerPositionTypeMaxValue = 3;
        public const byte FootballerBestSkillTypeMinValue = 0;
        public const byte FootballerBestSkillTypeMaxValue = 4;

        // Team
        public const byte TeamNameMinLength = 3;
        public const byte TeamNameMaxLength = 40;
        public const string TeamNameRegEx = @"^[A-Za-z0-9 .-]*$";
        public const byte TeamNationalityMinLength = 2;
        public const byte TeamNationalityMaxLength = 40;

        // Coach
        public const byte CoachNameMinLength = 2;
        public const byte CoachNameMaxLength = 40;
    }
}