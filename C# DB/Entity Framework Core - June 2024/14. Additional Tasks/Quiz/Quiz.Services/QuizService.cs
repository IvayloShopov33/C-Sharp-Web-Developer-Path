using Microsoft.EntityFrameworkCore;

using Quiz.Data;
using Quiz.Models;
using Quiz.Services.Contracts;
using Quiz.Services.Models;
using Quiz.Services.Models.Enums;
using static Quiz.Data.ModelsValidationConstraints;

namespace Quiz.Services
{
    public class QuizService : IQuizService
    {
        private readonly ApplicationDbContext dbContext;

        public QuizService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public int Add(string title)
        {
            if (title.Length < QuizTitleMinLength || dbContext.Quizzes.Any(x => x.Title == title))
            {
                throw new InvalidDataException();
            }

            var quiz = new Quiz.Models.Quiz
            {
                Title = title,
            };

            this.dbContext.Quizzes.Add(quiz);
            this.dbContext.SaveChanges();

            return quiz.Id;
        }

        public QuizViewModel GetQuizById(int id)
        {
            var quiz = this.dbContext.Quizzes
                .Include(x => x.Questions)
                .ThenInclude(x => x.Answers)
                .FirstOrDefault(x => x.Id == id);

            if (quiz == null)
            {
                throw new InvalidOperationException();
            }

            return new QuizViewModel
            {
                Id = quiz.Id,
                Title = quiz.Title,
                Questions = quiz.Questions.OrderBy(r => Guid.NewGuid()).Select(x => new QuestionViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Answers = x.Answers.OrderBy(r => Guid.NewGuid()).Select(y => new AnswerViewModel
                    {
                        Id = y.Id,
                        Title = y.Title,
                        QuestionId = y.QuestionId,
                        Points = y.Points,
                    })
                    .ToArray(),
                })
                .ToArray(),
            };
        }

        public IEnumerable<UserQuizViewModel> GetQuizzesByUserName(string userName)
        {
            var quizzes = this.dbContext.Quizzes
                .Select(x => new UserQuizViewModel
                {
                    QuizId = x.Id,
                    QuizTitle = x.Title,
                })
                .ToArray();

            foreach (var quiz in quizzes)
            {
                var questionsCount = this.dbContext.UsersAnswers
                    .Count(ua => ua.IdentityUser.UserName == userName && ua.Question.Id == quiz.QuizId);

                if (questionsCount == 0)
                {
                    quiz.QuizStatus = QuizStatus.NotStarted;
                    continue;
                }

                var answeredQuestionsCount = this.dbContext.UsersAnswers
                    .Count(ua => ua.IdentityUser.UserName == userName &&
                    ua.Question.Id == quiz.QuizId &&
                    ua.AnswerId.HasValue);

                if (answeredQuestionsCount == questionsCount)
                {
                    quiz.QuizStatus = QuizStatus.Finished;
                }
                else
                {
                    quiz.QuizStatus = QuizStatus.InProgress;
                }
            }

            return quizzes;
        }

        public void StartQuiz(string userName, int quizId)
        {
            if (this.dbContext.UsersAnswers.Any(x => x.IdentityUser.UserName == userName &&
                x.Question.QuizId == quizId))
            {
                return;
            }

            var userId = this.dbContext.Users
                .Where(x => x.UserName == userName)
                .Select(x => x.Id)
                .FirstOrDefault();

            var questionIds = this.dbContext.Questions
                .Where(x => x.QuizId == quizId)
                .Select(x => x.Id)
                .ToArray();

            foreach (var questionId in questionIds)
            {
                this.dbContext.UsersAnswers.Add(new UserAnswer
                {
                    AnswerId = null,
                    IdentityUserId = userId,
                    QuestionId = questionId,
                });
            }

            this.dbContext.SaveChanges();
        }
    }
}