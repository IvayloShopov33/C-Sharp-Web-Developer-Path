using Quiz.Services.Models;

namespace Quiz.Services.Contracts
{
    public interface IQuizService
    {
        int Add(string title);

        QuizViewModel GetQuizById(int id);

        IEnumerable<UserQuizViewModel> GetQuizzesByUserName(string userName);

        void StartQuiz(string userName, int quizId);
    }
}