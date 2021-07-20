using WebApi.Data.Models;

namespace WebApi.Data.Repositories
{
    public class ParticipantRepository : Repository<Participant>, IParticipantRepository
    {
        public ParticipantRepository(QuestionDbContext dbContext) : base(dbContext)
        {
        }
    }
}