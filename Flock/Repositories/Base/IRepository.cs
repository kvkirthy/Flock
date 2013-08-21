using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Flock.Models;

namespace Flock.Repositories.Base
{
    public interface IRepository<TEntity, in TId>
        where TEntity : IEntity<TId>
        where TId : struct
    {
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Retrieves an entity by its id.
        /// </summary>
        TEntity GetById(TId id);

        /// <summary>
        /// Adds a new entity to the system
        /// </summary>
        /// <param name="entity">The entity to add</param>
        void Add(TEntity entity);

        /// <summary>
        /// Updates an existing entity within the system
        /// </summary>
        /// <param name="entity">The modified entity to update</param>
        /// <returns>True if the entity was updated. False if it was not found.</returns>
        void Update(TEntity entity);

        /// <summary>
        /// Deletes an existing entity within the system
        /// </summary>
        /// <param name="id">Id of the document that needs to be deleted</param>
        void Delete(TId id);

        /// <summary>
        /// Get filtered results
        /// </summary>
        /// <param name="predicate">Predicate to be applied to get filtered data</param>
        /// <returns></returns>
        IEnumerable<TEntity> GetResultsByFilter(Func<TEntity, bool> predicate);
        IEnumerable<TEntity> GetAllOrderbyLastModifiedDescending();

    }
}
