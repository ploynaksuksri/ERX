using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Data.Models;

namespace WebApi.Core
{
    public interface IQuestionManager
    {
        Task<IList<Question>> GetAsync();

        Task<Question> GetAsync(int id);

        Task<Question> GetNextAsync(int participantId);

        Task<Question> AddAsync(Question question);

        Task Update(Question question);

        Task Delete(Question question);
    }
}