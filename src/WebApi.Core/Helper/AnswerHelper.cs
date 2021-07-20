using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Data.Models;
using System.Linq;

namespace WebApi.Core.Helper
{
    public class AnswerHelper
    {
        public static string GenerateCsv(List<Answer> answers)
        {
            var stringBuilder = new StringBuilder();
            foreach (var participant in answers.GroupBy(e => e.Participant))
            {
                var answerList = new List<string>();
                participant.ToList().ForEach(e => answerList.Add(GetAnswer(e)));
                stringBuilder.AppendLine($"{participant.Key.Id},{string.Join(",", answerList)}");
            }
            return stringBuilder.ToString();
        }

        private static string GetAnswer(Answer answer)
        {
            return answer.Question.IsMultipleChoice ? answer.Choice.Title : answer.WrittenAnswer;
        }
    }
}