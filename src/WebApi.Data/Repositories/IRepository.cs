using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Data.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();

        Task<IQueryable<TEntity>> Get(int id);

        TEntity Add(TEntity obj, bool autoSave = false);

        void Update(TEntity obj);

        void Delete(int id);

        void SaveChanges();
    }
}