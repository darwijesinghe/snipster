using Snipster.Library.Repository;
using System;
using System.Threading.Tasks;

namespace Snipster.Library.UOW
{
    /// <summary>
    /// Defines the contract for the Unit of Work pattern, which coordinates changes across multiple repositories
    /// and manages database transactions.
    /// <para><b>Warning:</b> Do not implement this interface yourself. 
    /// It uses the default <see cref="IGenericRepository{TEntity}"/> provided by this package.
    /// Use the provided implementation from the package instead.</para>
    /// <para><b>Note:</b> You may implement your own <see cref="IGenericRepository{TEntity}"/> if you want custom repository behavior.
    /// The <see cref="UnitOfWork"/> can work with your custom repository implementation as long as it implements <see cref="IGenericRepository{TEntity}"/>.</para>
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Gets the repository instance for the specified entity type.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <returns>
        /// An <see cref="IGenericRepository{TEntity}"/> instance for the given entity type.
        /// </returns>
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class;

        /// <summary>
        /// Asynchronously begins a new database transaction.
        /// </summary>
        Task BeginTransactionAsync();

        /// <summary>
        /// Asynchronously commits the current transaction, saving all changes to the database.
        /// </summary>
        Task CommitAsync();

        /// <summary>
        /// Asynchronously rolls back the current transaction, discarding all changes that were made during the transaction.
        /// </summary>
        Task RollbackAsync();

        /// <summary>
        /// Saves all changes made to the database.
        /// </summary>
        Task<bool> SaveChangesAsync();
    }
}
