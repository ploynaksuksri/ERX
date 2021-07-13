using WebApi.Data.Models;

namespace WebApi.Data.Repositories
{
    public interface IQuestionRepository : IRepository<Question>
    {
        Question GetByTitle(string title);
    }
}