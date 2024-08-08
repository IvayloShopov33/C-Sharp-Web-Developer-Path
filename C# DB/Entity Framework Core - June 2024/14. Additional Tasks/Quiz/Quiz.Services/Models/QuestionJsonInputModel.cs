using System.ComponentModel.DataAnnotations;
using static Quiz.Data.ModelsValidationConstraints;

namespace Quiz.Services.Models
{
    public class QuestionJsonInputModel
    {
        [StringLength(QuestionTitleMaxLength, MinimumLength = QuestionTitleMinLength)]
        public string Question { get; set; }

        public JsonAnswer[] Answers { get; set; }
    }
}