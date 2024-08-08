namespace Quiz.Services.Contracts
{
    public interface IAnswerService
    {
        int Add(string title, bool isCorrect, int points, int questionId);
    }
}