using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Infrastructure.UnitOfWork
{
    public class UnitOfWork<TContext> : IUnitOfWork, IDisposable where TContext : DbContext
    {
        #region Props

        private readonly ConcurrentDictionary<Type, object> _repositories;
        private IDesignTimeDbContextFactory<DbContext> ContextFactory { get; set; }

        private DbContext _context;
        public DbContext Context
        {
            get
            {
                if (_context == null)
                {
                    _context = this.ContextFactory.CreateDbContext( new[] {string.Empty});
                }
                return _context;
            }
        }
        private bool IsDisposed { get; set; }

        #endregion

        #region Constructor
        public UnitOfWork(IDesignTimeDbContextFactory<DbContext> factory)
        {
            ContextFactory = factory;
            _repositories = new ConcurrentDictionary<Type, object>();
        }

        #endregion

        #region Methods
        public bool CheckDBExists()
        {
            return this.Context.Database.EnsureCreated();
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            return (Repository<TEntity>)_repositories.GetOrAdd(typeof(TEntity), new Repository<TEntity>(this.Context));
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.IsDisposed && disposing && _context != null)
            {
                _context.Dispose();
            }
            this.IsDisposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

    }
}
