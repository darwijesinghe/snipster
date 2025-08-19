namespace Snipster.Test.Models
{
    /// <summary>
    /// Represents a test log used for unit testing purposes.
    /// </summary>
    public class TestLog
    {
        /// <summary>
        /// Gets or sets the unique identifier for the test log.
        /// </summary>
        public int Id             { get; set; }

        /// <summary>
        /// Gets or sets the message of the test log.
        /// </summary>
        public string? Message    { get; set; }

        /// <summary>
        /// Gets or sets the exception associated with the test log, if any.
        /// </summary>
        public string? StackTrace { get; set; }

        /// <summary>
        /// Gets or sets the source of the test log, typically the class or method that generated it.
        /// </summary>
        public string? Source     { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the log was created.
        /// </summary>
        public DateTime LoggedAt  { get; set; } = DateTime.UtcNow;
    }
}
