using WebApi.Data.Models;

namespace WebApi.Core.Checker
{
    public interface IAnswerChecker
    {
        bool IsValid(Answer answer);
    }
}