using Quiz.Services.Models;

namespace Quiz.Services.Contracts
{
    public interface IUserAnswerService
    {
        string AddUserAnswer(string userName, int questionId, int answerId);

        void BulkAddUserAnswer(QuizInputModel quizInputModel);

        int GetUserResult(string userName, int quizId);
    }
}