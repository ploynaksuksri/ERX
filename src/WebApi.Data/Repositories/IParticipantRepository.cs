using System.Threading.Tasks;
using WebApi.Data.Models;

namespace WebApi.Data.Repositories
{
    public interface IParticipantRepository : IRepository<Participant>
    {
        new Task<Participant> Get(int id);
    }
}