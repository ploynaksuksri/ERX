using WebApi.Data.Models;
using System.Linq;

namespace WebApi.Data.Repositories
{
    public class QuestionRepository : Repository<Question>, IQuestionRepository
    {
        public QuestionRepository(QuestionDbContext dbContext) : base(dbContext)
        {
        }

        public Question GetByTitle(string title)
        {
            return _dbContext.Questions.FirstOrDefault(e => e.Title == title);
        }
    }
}