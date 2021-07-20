using System.Collections.Generic;
using System.Linq;
using WebApi.Data;
using WebApi.Data.Models;

namespace WebApi.Core.Checker
{
    public class CountryChecker : IAnswerChecker
    {
        public List<string> NotAllowedCountries = new List<string>()
        {
            "Cambodia", "Myanmar, Pakistan"
        };

        public bool IsValid(Answer answer)
        {
            if (answer.Question.Title == QuestionConstants.CountryOfResidence)
                return !NotAllowedCountries.Contains(answer.Choice.Title);
            return true;
        }
    }
}