using Quiz.Data;
using Quiz.Models;
using Quiz.Services.Contracts;
using static Quiz.Data.ModelsValidationConstraints;

namespace Quiz.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly ApplicationDbContext dbContext;

        public AnswerService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public int Add(string title, bool isCorrect, int points, int questionId)
        {
            if (title.Length < AnswerTitleMinLength ||
                points < AnswerPointsMinValue || points > AnswerPointsMaxValue ||
                this.dbContext.Answers.Any(x => x.Title == title && x.QuestionId == questionId))
            {
                throw new InvalidDataException();
            }

            var answer = new Answer
            {
                Title = title,
                IsCorrect = isCorrect,
                Points = points,
                QuestionId = questionId,
            };

            this.dbContext.Answers.Add(answer);
            this.dbContext.SaveChanges();

            return answer.Id;
        }
    }
}