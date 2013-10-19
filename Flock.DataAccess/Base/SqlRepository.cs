using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using Flock.DataAccess.EntityFramework;

namespace Flock.DataAccess.Base
{
    public class SqlRepository<T> : IRepository<T> where T : class
    {
        private readonly FlockContext _context;
        protected DbContext DbContext { get; set; }
        protected DbSet<T> DbSet { get; set; }

        public SqlRepository(FlockContext context)
        {
            _context = context;
            DbSet = _context.Set<T>();
        }

        public virtual IQueryable<T> GetAll()
        {
            return DbSet;

        }

        public virtual T GetById(int id)
        {

            return DbSet.Find(id);
        }

        public virtual void Add(T entity)
        {
            DbEntityEntry dbEntityEntry = _context.Entry(entity);
            if (dbEntityEntry.State != EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Added;
            }
            else
            {
                DbSet.Add(entity);
                SaveChanges();
            }
        }

        public virtual void Update(T entity)
        {
            DbEntityEntry dbEntityEntry = _context.Entry(entity);
            DbSet.Attach(entity);
            dbEntityEntry.State = EntityState.Modified;
            SaveChanges();
        }

        public virtual void Delete(T entity)
        {
            DbEntityEntry dbEntityEntry = _context.Entry(entity);
            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                DbSet.Attach(entity);
                SaveChanges();
            }
        }

        public virtual void Delete(int id)
        {
            var entity = GetById(id);
            if (entity == null) return;
            Delete(entity);
            SaveChanges();
        }

        public void SaveChanges()
        {
            try
            {
                _context.SaveChanges();
            }
            catch(DbEntityValidationException ex)
            {
                foreach (var failure in ex.EntityValidationErrors) {
          
            }
            }
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
