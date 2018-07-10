using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Catalog.Infrastructure.UnitOfWork
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity: class
    {
        private DbContext Context { get; set; }

        public Repository(DbContext context)
        {
            this.Context = context;
        }

        public virtual IEnumerable<TEntity> FindAll()
        {
            IQueryable<TEntity> query = null;

            query = this.Context.Set<TEntity>();

            return query.ToList();
        }

        public TEntity FindById(int id)
        {
            return this.Context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> where)
        {
            IQueryable<TEntity> query = null;

            query = where == null ? Context.Set<TEntity>() : this.Context.Set<TEntity>().Where(where);

            return query.ToList();
        }
    }
}
