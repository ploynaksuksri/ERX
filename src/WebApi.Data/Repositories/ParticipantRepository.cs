using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebApi.Data.Models;

namespace WebApi.Data.Repositories
{
    public class ParticipantRepository : Repository<Participant>, IParticipantRepository
    {
        public ParticipantRepository(QuestionDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Participant> Get(int id)
        {
            return await _dbContext.Participants.Include(e => e.LastQuestion).FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}