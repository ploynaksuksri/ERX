using System.Collections.Generic;

namespace WebApi.Data.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();

        TEntity Get(int id);

        TEntity Add(TEntity obj, bool autoSave = false);

        void Update(TEntity obj);

        void Delete(int id);

        void SaveChanges();
    }
}