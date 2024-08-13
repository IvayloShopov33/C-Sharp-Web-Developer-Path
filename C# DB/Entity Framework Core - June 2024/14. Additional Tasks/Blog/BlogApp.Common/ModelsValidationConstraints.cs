namespace BlogApp.Common
{
    public class ModelsValidationConstraints
    {
        public const byte ArticleTitleMinLength = 5;
        public const byte ArticleTitleMaxLength = 128;

        public const byte ArticleContentMinLength = 10;
        public const int ArticleContentMaxLength = 4096;

        public const byte ArticleCategoryMinLength = 5;
        public const byte ArticleCategoryMaxLength = 100;
    }
}