using WebApi.Data.Models;

namespace WebApi.Data.Repositories
{
    public class QuestionRepository : Repository<Question>, IQuestionRepository
    {
        public QuestionRepository(QuestionDbContext dbContext) : base(dbContext)
        {

        }
    }
}