using Quiz.Data;
using Quiz.Models;
using Quiz.Services.Contracts;
using Quiz.Services.Models;

namespace Quiz.Services
{
    public class UserAnswerService : IUserAnswerService
    {
        private readonly ApplicationDbContext dbContext;

        public UserAnswerService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public string AddUserAnswer(string userName, int questionId, int answerId)
        {
            var userId = this.dbContext.Users
                .Where(x => x.UserName == userName)
                .Select(x => x.Id)
                .FirstOrDefault();

            var userAnswer = this.dbContext.UsersAnswers
                .FirstOrDefault(x => x.IdentityUserId == userId && x.QuestionId == questionId);
            userAnswer.AnswerId = answerId;

            this.dbContext.SaveChanges();

            return userAnswer.IdentityUserId;
        }

        public void BulkAddUserAnswer(QuizInputModel quizInputModel)
        {
            var usersAnswers = new List<UserAnswer>();

            foreach (var questionWithAnswer in quizInputModel.QuestionsWithAnswers)
            {
                var userAnswer = new UserAnswer
                {
                    IdentityUserId = quizInputModel.UserId,
                    QuestionId = questionWithAnswer.QuestionId,
                    AnswerId = questionWithAnswer.QuestionId,
                };

                usersAnswers.Add(userAnswer);
            }

            this.dbContext.UsersAnswers.AddRange(usersAnswers);
            this.dbContext.SaveChanges();
        }

        public int GetUserResult(string userName, int quizId)
        {
            var userId = this.dbContext.Users
                .Where(x => x.UserName == userName)
                .Select(x => x.Id)
                .FirstOrDefault();

            int totalPoints = this.dbContext.UsersAnswers
                .Where(x => x.IdentityUserId == userId && x.Question.QuizId == quizId)
                .Sum(x => x.Answer.Points);

            return totalPoints;
        }
    }
}