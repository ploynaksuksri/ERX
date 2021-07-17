using System.Collections.Generic;
using System.Linq;

namespace WebApi.Core.Checker
{
    public class CountryChecker : IAnswerChecker
    {
        public List<string> NotAllowedCountries = new List<string>()
        {
            "Cambodia", "Myanmar, Pakistan"
        };

        public bool IsValid(string answer)
        {
            return !NotAllowedCountries.Contains(answer.ToString());
        }
    }
}