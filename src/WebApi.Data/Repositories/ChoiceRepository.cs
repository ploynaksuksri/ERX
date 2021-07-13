using WebApi.Data.Models;

namespace WebApi.Data.Repositories
{
    public class ChoiceRepository : Repository<Choice>, IChoiceRepository
    {
        public ChoiceRepository(QuestionDbContext dbContext) : base(dbContext)
        {
        }
    }
}