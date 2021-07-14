using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Data.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> Get(int id);

        Task<TEntity> Add(TEntity obj, bool autoSave = false);

        Task Update(TEntity obj);

        Task Delete(TEntity obj);

        Task SaveChanges();
    }
}