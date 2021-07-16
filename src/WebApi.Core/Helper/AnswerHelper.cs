using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Data.Models;

namespace WebApi.Core.Helper
{
    public class AnswerHelper
    {
        public static string GenerateCsv(List<Answer> answers)
        {
            var stringBuilder = new StringBuilder();
            foreach (var answer in answers)
            {
                var textAnswer = answer.Question.IsMultipleChoice ? answer.Choice.Title : answer.WrittenAnswer;
                stringBuilder.AppendLine($"{answer.Question.Title},{textAnswer}");
            }
            return stringBuilder.ToString();
        }
    }
}