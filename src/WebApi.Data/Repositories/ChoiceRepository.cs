using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data.Models;

namespace WebApi.Data.Repositories
{
    public class ChoiceRepository : Repository<Choice>, IChoiceRepository
    {
        public ChoiceRepository(QuestionDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Choice> CheckExist(string title, int questionId)
        {
            return await _dbContext.Choices.Where(e => !e.IsDeleted).Include(e => e.Question).FirstOrDefaultAsync(e => e.Title == title && e.Question.Id == questionId);
        }
    }
}