using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Snipster.Library.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Snipster.Library.UOW
{
    /// <summary>
    /// Provides an implementation of the Unit of Work pattern, managing database transactions and repositories.
    /// </summary>
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext                _context;
        private IDbContextTransaction?            _transaction;
        private readonly Dictionary<Type, object> _repositories;
        private readonly bool                     _disposeContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="context">The database context to be used for the unit of work.</param>
        /// <param name="disposeContext">Whether the UnitOfWork owns the DbContext and should dispose it.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="context"/> is null.
        /// </exception>
        public UnitOfWork(DbContext context, bool disposeContext = true)
        {
            _context        = context ?? throw new ArgumentNullException(nameof(context));
            _disposeContext = disposeContext;
            _repositories   = new Dictionary<Type, object>();
        }

        /// <inheritdoc/>
        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            if (_repositories.TryGetValue(typeof(TEntity), out var repo))
                return (IGenericRepository<TEntity>)repo;

            var repository = new GenericRepository<TEntity>(_context);
            _repositories[typeof(TEntity)] = repository;

            return repository;
        }

        /// <inheritdoc/>
        public async Task BeginTransactionAsync()
        {
            if (_transaction == null)
                _transaction = await _context.Database.BeginTransactionAsync();
        }

        /// <inheritdoc/>
        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
            if (_transaction != null)
            {
                await _transaction.CommitAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        /// <inheritdoc/>
        public async Task RollbackAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        /// <inheritdoc/>
        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// Disposes the transaction (if any) and the underlying DbContext resources.
        /// </summary>
        public void Dispose()
        {
            _transaction?.Dispose();
            if (_disposeContext)
                _context.Dispose();
        }
    }
}
