using Quiz.Data;
using Quiz.Models;
using Quiz.Services.Contracts;
using static Quiz.Data.ModelsValidationConstraints;

namespace Quiz.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly ApplicationDbContext dbContext;

        public QuestionService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public int Add(string title, int quizId)
        {
            if (title.Length < QuestionTitleMinLength || dbContext.Questions.Any(x => x.Title == title))
            {
                throw new InvalidDataException();
            }

            var question = new Question
            {
                Title = title,
                QuizId = quizId
            };

            this.dbContext.Questions.Add(question);
            this.dbContext.SaveChanges();

            return question.Id;
        }
    }
}