namespace Quiz.Data
{
    public static class ModelsValidationConstraints
    {
        // Quiz
        public const byte QuizTitleMinLength = 3;
        public const byte QuizTitleMaxLength = 100;

        // Question
        public const byte QuestionTitleMinLength = 5;
        public const byte QuestionTitleMaxLength = 200;

        // Answer
        public const byte AnswerTitleMinLength = 3;
        public const byte AnswerTitleMaxLength = 60;
        public const int AnswerPointsMinValue = 0;
        public const int AnswerPointsMaxValue = 3;
    }
}