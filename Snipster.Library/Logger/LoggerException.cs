using System;

namespace Snipster.Library.Logger
{
    /// <summary>
    /// Represents an exception that occurs during logging operations.
    /// </summary>
    public sealed class LoggerException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoggerException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public LoggerException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
