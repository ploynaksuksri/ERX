using System.Threading.Tasks;
using WebApi.Data.Models;

namespace WebApi.Data.Repositories
{
    public interface IChoiceRepository : IRepository<Choice>
    {
        Task<Choice> CheckExist(string title, int questionId);
    }
}