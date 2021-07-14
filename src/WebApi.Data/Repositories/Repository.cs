using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data.Models;

namespace WebApi.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
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

        public async Task Delete(TEntity obj)
        {
            obj.IsDeleted = true;
            _dbContext.Set<TEntity>().Update(obj);
            await SaveChanges();
        }

        public virtual async Task<TEntity> Get(int id)
        {
            return await GetAll().FirstOrDefaultAsync(e => e.Id == id && !e.IsDeleted);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().Where(e => !e.IsDeleted);
        }

        public virtual async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task Update(TEntity obj)
        {
            _dbContext.Entry(obj).State = EntityState.Modified;
            await SaveChanges();
        }

        public virtual async Task<TEntity> Add(TEntity obj, bool autoSave = false)
        {
            _dbContext.Set<TEntity>().Add(obj);
            if (autoSave)
            {
                await SaveChanges();
            }

            return obj;
        }
    }
}