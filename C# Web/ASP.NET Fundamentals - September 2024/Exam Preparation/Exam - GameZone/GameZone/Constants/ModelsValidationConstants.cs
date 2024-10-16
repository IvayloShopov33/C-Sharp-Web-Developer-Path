namespace GameZone.Constants
{
    public static class ModelsValidationConstants
    {
        // Game
        public const byte GameTitleMinLength = 2;
        public const byte GameTitleMaxLength = 50;
        public const byte GameDescriptionMinLength = 10;
        public const int GameDescriptionMaxLength = 500;
        public const string GameReleasedOnDateFormat = "yyyy-MM-dd";

        // Genre
        public const byte GenreNameMinLength = 3;
        public const byte GenreNameMaxLength = 25;
    }
}