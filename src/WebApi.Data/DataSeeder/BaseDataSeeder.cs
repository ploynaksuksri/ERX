using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Data.Repositories;

namespace WebApi.Data.DataSeeder
{
    public abstract class BaseDataSeeder<TEntity> where TEntity : class
    {
        protected IRepository<TEntity> _repository;

        public BaseDataSeeder(IRepository<TEntity> repository)
        {
            _repository = repository;
        }
    }
}