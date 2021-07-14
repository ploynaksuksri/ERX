using WebApi.Data.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace WebApi.Data.Repositories
{
    public class QuestionRepository : Repository<Question>, IQuestionRepository
    {
        public QuestionRepository(QuestionDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Question> GetByTitle(string title)
        {
            return await _dbContext.Questions.FirstOrDefaultAsync(e => e.Title == title);
        }

        public async Task<Question> Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Question>> GetAll()
        {
            return await _dbContext.Questions.Include(e => e.Choices).ToListAsync();
        }
    }
}