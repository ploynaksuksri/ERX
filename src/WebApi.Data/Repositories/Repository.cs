using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApi.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        protected List<TEntity> _list = new List<TEntity>();
        protected QuestionDbContext _dbContext;

        public Repository(QuestionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Repository()
        {
        }

        public void Deleted(TEntity obj)
        {
            _list.Remove(obj);
        }

        public void Delete(int id)
        {
        }

        public TEntity Get(int id)
        {
            return _list.FirstOrDefault();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public virtual void Update(TEntity obj)
        {
            throw new NotImplementedException();
        }

        TEntity IRepository<TEntity>.Add(TEntity obj, bool autoSave = false)
        {
            _dbContext.Set<TEntity>().Add(obj);
            if (autoSave)
            {
                _dbContext.SaveChanges();
            }

            return obj;
        }
    }
}