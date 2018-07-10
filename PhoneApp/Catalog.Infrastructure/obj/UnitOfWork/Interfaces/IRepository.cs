using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Infrastructure.UnitOfWork
{
    public interface IRepository<TEntity>
    {
        IEnumerable<TEntity> FindAll();
    }
}
