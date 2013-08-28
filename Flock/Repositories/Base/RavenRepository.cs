using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Flock.Models;
using Raven.Client;

namespace Flock.Repositories.Base
{
    public class RavenRepository<TEntity, TId> : IRepository<TEntity, TId>
        where TEntity : IEntity<TId>
        where TId : struct
    {
        protected IDocumentSession Session { get; private set; }

        public RavenRepository(IDocumentSession session)
        {
            Session = session;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Session.Query<TEntity>();
        }

        public TEntity GetById(TId id)
        {
            return Session.Load<TEntity>(id);
        }

        public void Add(TEntity entity)
        {
            Session.Store(entity);
            Session.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            Session.Store(entity);
            Session.SaveChanges();
        }

        public void Delete(TId id)
        {
            Session.Delete(GetById(id));
            Session.SaveChanges();
        }

        public IEnumerable<TEntity> GetResultsByFilter(Func<TEntity, bool> predicate)
        {
            return Session.Query<TEntity>().Where(predicate);
        }

        public IEnumerable<TEntity> GetAllOrderbyLastModifiedDescending()
        {
            return Session.Advanced.LuceneQuery<TEntity>()
                .WaitForNonStaleResultsAsOfNow()
                .OrderByDescending("[\"@metadata\"][\"Last-Modified\"]")
                .ToList();
        }

    }

}
