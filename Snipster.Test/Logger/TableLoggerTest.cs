using Microsoft.EntityFrameworkCore;
using Snipster.Library.Logger;
using Snipster.Test.Models;

namespace Snipster.Test.Logger
{
    /// <summary>
    /// Tests for the TableLogger class.
    /// </summary>
    [TestClass]
    public class TableLoggerTest
    {
        private readonly DbContextOptions<TestAppDbContext> _options;
        private readonly TestAppDbContext                   _context;
        private readonly ITableLogger<TestLog>              _logger;

        public TableLoggerTest()
        {
            // configure the in-memory database for testing
            _options = new DbContextOptionsBuilder<TestAppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            // create a new instance of the test application database context
            _context = new TestAppDbContext(_options);

            // create the logger
            _logger = new TableLogger<TestLog>(() => new TestAppDbContext(_options));
        }

        /// <summary>
        /// Tests that the logger can log an entry to the database table asynchronously.
        /// </summary>
        [TestMethod]
        public async Task LogToTableAsync_ShouldLogEntry()
        {
            // Arrange
            var ex = new Exception("Test exception");
            var logEntry = new TestLog
            {
                Message    = "Test log message",
                StackTrace = ex.StackTrace,
                Source     = "Test source"
            };

            // Act
            await _logger.LogToTableAsync(logEntry);

            // Assert
            var loggedEntry = await _context.TestLog.FirstOrDefaultAsync();
            Assert.IsNotNull(loggedEntry);
            Assert.AreEqual(logEntry.Message, loggedEntry.Message);
            Assert.AreEqual(logEntry.StackTrace, loggedEntry.StackTrace);
            Assert.AreEqual(logEntry.Source, loggedEntry.Source);
        }

        /// <summary>
        /// Tests that the logger throws task cancelled exception when the cancellation token is cancelled.
        /// </summary>
        [TestMethod]
        public async Task LogToTableAsync_ShouldCancelLogging_WhenCancelled()
        {
            // Arrange
            var logEntry = new TestLog
            {
                Message    = "Test log message",
                StackTrace = "Test stack trace",
                Source     = "Test source"
            };

            using var cts = new CancellationTokenSource();
            cts.Cancel(); // cancel the token immediately

            // Act & Assert
            await Assert.ThrowsExceptionAsync<TaskCanceledException>(
                () => _logger.LogToTableAsync(logEntry, cts.Token)
            );
        }

        /// <summary>
        /// Tests that the logger can process multiple log entries concurrently without conflicts.
        /// </summary>
        [TestMethod]
        public async Task ShouldProcessLogsWithoutConcurrentConflicts()
        {
            // Arrange
            var logs = Enumerable.Range(1, 10)
                                 .Select(i => new TestLog
                                 {
                                     Message    = $"Log {i}",
                                     StackTrace = $"StackTrace {i}",
                                     Source     = $"Test{i}"
                                 })
                                 .ToList();

            using var cts = new CancellationTokenSource();

            // Act: simulate concurrent logging
            var tasks = logs.Select(log => _logger.LogToTableAsync(log, cts.Token)).ToArray();

            // run all logging tasks concurrently
            await Task.WhenAll(tasks);

            // Assert: all logs are saved and no exceptions occurred
            var savedLogs = await _context.TestLog.ToListAsync();
            Assert.AreEqual(logs.Count, savedLogs.Count);
        }
    }
}
