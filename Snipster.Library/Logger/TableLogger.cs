using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Snipster.Library.Logger
{
    /// <summary>
    /// A logger that writes log entries to a database table using Entity Framework Core.
    /// </summary>
    /// <typeparam name="TLog">The type of log entry to be stored in the table.</typeparam>
    public sealed class TableLogger<TLog> : ITableLogger<TLog> where TLog : class
    {
        private readonly Func<DbContext>       _context;
        private readonly ConcurrentQueue<TLog> _logQueue;
        private readonly SemaphoreSlim         _semaphore;

        /// <summary>
        /// Initializes a new instance of the <see cref="TableLogger{TLog}"/> class.
        /// </summary>
        /// <param name="context">A factory function to create instances of the DbContext.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the dbContext is null.
        /// </exception>
        public TableLogger(Func<DbContext> context)
        {
            _context   = context ?? throw new ArgumentNullException(nameof(context));
            _logQueue  = new ConcurrentQueue<TLog>();
            _semaphore = new SemaphoreSlim(1); // limit to one concurrent batch processing
        }

        /// <inheritdoc/>
        public async Task LogToTableAsync(TLog log, CancellationToken cancellationToken = default)
        {
            if (log == null)
                throw new ArgumentNullException(nameof(log));

            // enqueue the log entry for processing
            _logQueue.Enqueue(log);

            await ProcessQueueAsync(cancellationToken);
        }

        /// <summary>
        /// Processes the log queue asynchronously, writing batches of log entries to the database.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token to observe while waiting for the task to complete.</param>
        /// <exception cref="LoggerException">
        /// Thrown when a critical failure occurs while logging to the database.
        /// </exception>
        private async Task ProcessQueueAsync(CancellationToken cancellationToken)
        {
            if (!await _semaphore.WaitAsync(0, cancellationToken))
                return; // another batch is already processing

            try
            {
                while (!_logQueue.IsEmpty && !cancellationToken.IsCancellationRequested)
                {
                    var batch = new List<TLog>();

                    // dequeue up to 50 logs per batch
                    while (_logQueue.TryDequeue(out var log) && batch.Count < 50)
                        batch.Add(log);

                    if (batch.Count == 0)
                        break;

                    try
                    {
                        await using var context = _context();
                        await context.Set<TLog>().AddRangeAsync(batch, cancellationToken);
                        await context.SaveChangesAsync(cancellationToken);
                    }
                    catch (Exception ex)
                    {
                        // Propagate critical failures
                        Console.Error.WriteLine($"Logging failed: {ex}");
                        throw new LoggerException("Critical failure while logging.", ex);
                    }
                }
            }
            finally
            {
                _semaphore.Release();
            }
        }
    }
}
