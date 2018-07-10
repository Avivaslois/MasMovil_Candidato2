using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Catalog.Infrastructure.UnitOfWork
{
    public interface IRepository<TEntity>
    {
        IEnumerable<TEntity> FindAll();

        TEntity FindById(int id);

        IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> where); 
    }
}
