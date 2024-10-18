namespace SeminarHub.Common
{
    public class ModelsValidationConstraints
    {
        // Seminar
        public const byte SeminarTopicMinLength = 3;
        public const byte SeminarTopicMaxLength = 100;
        public const byte SeminarLecturerMinLength = 5;
        public const byte SeminarLecturerMaxLength = 60;
        public const byte SeminarDetailsMinLength = 10;
        public const int SeminarDetailsMaxLength = 500;
        public const string SeminarDateAndTimeDateFormat = "dd.MM.yyyy HH:mm";
        public const byte SeminarDurationMinValue = 30;
        public const byte SeminarDurationMaxValue = 180;

        // Category
        public const byte CategoryNameMinLength = 3;
        public const byte CategoryNameMaxLength = 50;
    }
}