using System.Text.Json;

using Quiz.Services.Contracts;
using Quiz.Services.Models;
using static Quiz.Common.ModelsValidator;

namespace Quiz.Services
{
    public class JsonInputService : IJsonInputService
    {
        private readonly IQuestionService questionService;
        private readonly IAnswerService answerService;

        public JsonInputService(IQuestionService questionService, IAnswerService answerService)
        {
            this.questionService = questionService;
            this.answerService = answerService;
        }

        public void Import(string fileName)
        {
            var json = File.ReadAllText(fileName);
            var questions = (QuestionJsonInputModel[])JsonSerializer.Deserialize(json, typeof(QuestionJsonInputModel[]));

            foreach (var question in questions)
            {
                if (!IsValid(question))
                {
                    Console.WriteLine("Invalid question input.");
                    continue;
                }

                var questionId = this.questionService.Add(question.Question, 1);

                foreach (var answer in question.Answers)
                {
                    if (!IsValid(answer))
                    {
                        Console.WriteLine("Invalid answer input.");
                        continue;
                    }

                    this.answerService.Add(answer.Answer, answer.Correct, answer.Points, questionId);
                }
            }
        }
    }
}