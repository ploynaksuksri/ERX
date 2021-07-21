using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Data.Models;

namespace WebApi.Data.Repositories
{
    public interface IQuestionRepository : IRepository<Question>
    {
        Task<Question> GetByTitle(string title);

        new Task<List<Question>> GetAll();

        new Task<Question> Get(int id);

        Task<Question> GetByOrder(int order);
    }
}