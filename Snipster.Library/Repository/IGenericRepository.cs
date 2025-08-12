using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Snipster.Library.Repository
{
    /// <summary>
    /// Defines the contract for basic CRUD operations on entities of type <typeparamref name="TEntity"/>.
    /// </summary>
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Retrieves all entities with optional eager loading.
        /// </summary>
        /// <param name="include">Optional function to include related entities.</param>
        Task<IEnumerable<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null);

        /// <summary>
        /// Retrieves all entities matching a condition, with optional eager loading.
        /// </summary>
        /// <param name="predicate">The filter expression.</param>
        /// <param name="include">Optional function to include related entities.</param>
        Task<IEnumerable<TEntity>> GetAllByConditionAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null);

        /// <summary>
        /// Retrieves the first entity matching a condition, with optional eager loading.
        /// </summary>
        /// <param name="predicate">The filter expression.</param>
        /// <param name="include">Optional function to include related entities.</param>
        Task<TEntity?> GetByConditionAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null);

        /// <summary>
        /// Projects a selection of fields from entities.
        /// </summary>
        /// <typeparam name="TResult">The type of the projected result.</typeparam>
        /// <param name="selector">Expression defining selected fields.</param>
        Task<IEnumerable<TResult>> GetSelectedColumnsAsync<TResult>(Expression<Func<TEntity, TResult>> selector);

        /// <summary>
        /// Determines if any entity exists that matches a condition.
        /// </summary>
        /// <param name="predicate">The filter expression.</param>
        Task<bool> IsExistAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Adds a new entity to the database.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        Task AddAsync(TEntity entity);

        /// <summary>
        /// Adds multiple entities to the database.
        /// </summary>
        /// <param name="entities">The list of entities to add.</param>
        Task AddRangeAsync(IEnumerable<TEntity> entities);

        /// <summary>
        /// Updates an existing entity.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        void Update(TEntity entity);

        /// <summary>
        /// Updates multiple entities.
        /// </summary>
        /// <param name="entities">The list of entities to update.</param>
        void UpdateRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Removes an entity from the database.
        /// </summary>
        /// <param name="entity">The entity to remove.</param>
        void Remove(TEntity entity);

        /// <summary>
        /// Removes an entity by its identifier.
        /// </summary>
        /// <param name="id">The primary key of the entity to remove.</param>
        Task RemoveAsync(object id);

        /// <summary>
        /// Saves all changes made to the database.
        /// </summary>
        Task<bool> SaveChangesAsync();
    }
}
