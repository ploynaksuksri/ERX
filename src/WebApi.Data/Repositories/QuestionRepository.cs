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
            return await _dbContext.Questions.Include(e => e.Choices).FirstOrDefaultAsync(e => e.Title == title);
        }

        public async Task<Question> Get(int id)
        {
            return await _dbContext.Questions.Include(e => e.Choices).FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<Question>> GetAll()
        {
            return await _dbContext.Questions.Include(e => e.Choices).ToListAsync();
        }

        public async Task<Question> GetByOrder(int order)
        {
            return await _dbContext.Questions.Include(e => e.Choices).FirstOrDefaultAsync(e => e.Order == order);
        }
    }
}