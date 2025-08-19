using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Snipster.Library.Repository
{
    /// <summary>
    /// Provides a generic implementation of <see cref="IGenericRepository{TEntity}"/> 
    /// for performing CRUD operations with a shared <see cref="DbContext"/>.
    /// </summary>
    public sealed class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly DbContext      _context;
        private readonly DbSet<TEntity> _dbSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericRepository{TEntity}"/> class.
        /// </summary>
        /// <param name="context">The <see cref="DbContext"/> to use for database operations.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="context"/> is null.
        /// </exception>
        public GenericRepository(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet   = context.Set<TEntity>();

            // Debugging aid
            Debug.WriteLine("DbContext Hash: " + _context.GetHashCode());
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null)
        {
            IQueryable<TEntity> query = _dbSet;

            if (include != null)
                query = include(query);

            return await query.AsNoTracking().ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<TEntity>> GetAllByConditionAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null)
        {
            IQueryable<TEntity> query = _dbSet.Where(predicate);

            if (include != null)
                query = include(query);

            return await query.AsNoTracking().ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<TEntity?> GetByConditionAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null)
        {
            IQueryable<TEntity> query = _dbSet.Where(predicate);

            if (include != null)
                query = include(query);

            return await query.AsNoTracking().FirstOrDefaultAsync();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<TResult>> GetSelectedColumnsAsync<TResult>(Expression<Func<TEntity, TResult>> selector)
            => await _dbSet.AsNoTracking().Select(selector).ToListAsync();

        /// <inheritdoc/>
        public async Task<bool> IsExistAsync(Expression<Func<TEntity, bool>> predicate)
            => await _dbSet.AsNoTracking().AnyAsync(predicate);

        /// <inheritdoc/>
        public async Task AddAsync(TEntity entity)
            => await _dbSet.AddAsync(entity);

        /// <inheritdoc/>
        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
            => await _dbSet.AddRangeAsync(entities);

        /// <inheritdoc/>
        public void Update(TEntity entity)
            => _dbSet.Update(entity);

        /// <inheritdoc/>
        public void UpdateRange(IEnumerable<TEntity> entities)
            => _dbSet.UpdateRange(entities);

        /// <inheritdoc/>
        public void Remove(TEntity entity)
            => _dbSet.Remove(entity);

        /// <inheritdoc/>
        public async Task RemoveAsync(object id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
                _dbSet.Remove(entity);
        }

        /// <inheritdoc/>
        public async Task<bool> SaveChangesAsync()
            => await _context.SaveChangesAsync() > 0;
    }
}
