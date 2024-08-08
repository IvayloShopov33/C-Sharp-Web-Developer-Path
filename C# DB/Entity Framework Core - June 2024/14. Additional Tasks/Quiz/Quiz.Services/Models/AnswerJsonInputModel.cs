using System.ComponentModel.DataAnnotations;
using static Quiz.Data.ModelsValidationConstraints;

namespace Quiz.Services.Models
{
    public class JsonAnswer
    {
        [StringLength(AnswerTitleMaxLength, MinimumLength = AnswerTitleMinLength)]
        public string Answer { get; set; }

        public bool Correct { get; set; }

        [Range(AnswerPointsMinValue, AnswerPointsMaxValue)]
        public int Points { get; set; }
    }
}