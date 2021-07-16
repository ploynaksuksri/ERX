using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Data.Models;

namespace WebApi.Data.Repositories
{
    public interface IAnswerRepository : IRepository<Answer>
    {
        Task<List<Answer>> GetAll();
    }
}