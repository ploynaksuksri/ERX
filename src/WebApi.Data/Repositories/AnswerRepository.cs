using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data.Models;

namespace WebApi.Data.Repositories
{
    public class AnswerRepository : Repository<Answer>, IAnswerRepository
    {
        public AnswerRepository(QuestionDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Answer>> GetAll()
        {
            return await _dbContext.Answers
                .Where(e => !e.IsDeleted)
                .Include(e => e.Question)
                .Include(e => e.Choice)
                .Include(e => e.Participant)
                .ToListAsync();
        }
    }
}