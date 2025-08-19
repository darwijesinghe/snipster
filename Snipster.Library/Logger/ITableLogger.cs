using System;
using System.Threading;
using System.Threading.Tasks;

namespace Snipster.Library.Logger
{
    /// <summary>
    /// Interface for logging to a database table.
    /// </summary>
    /// <typeparam name="TLog">
    /// The type of log entry to be stored in the table.
    /// </typeparam>
    public interface ITableLogger<TLog> where TLog : class
    {
        /// <summary>
        /// Asynchronously enqueues a log entry for storage in a database table.
        /// The log entry will be written to the database in batches by a background process.
        /// </summary>
        /// <param name="log">The log entry to be stored.</param>
        /// <param name="cancellationToken">A cancellation token to observe while waiting for the task to complete.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the <paramref name="log"/> parameter is null.
        /// </exception>
        Task LogToTableAsync(TLog log, CancellationToken cancellationToken = default);
    }
}
