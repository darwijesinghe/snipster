namespace Snipster.Test.Models
{
    /// <summary>
    /// Represents the status of a sample operation.
    /// </summary>
    public enum Status
    {
        /// <summary>
        /// Indicates that the operation was successful.
        /// </summary>
        [System.ComponentModel.Description("Operation successful")]
        Success,

        /// <summary>
        /// Indicates that the operation failed.
        /// </summary>
        [System.ComponentModel.Description("Operation failed")]
        Failure,

        /// <summary>
        /// Indicates that the operation is pending and has not yet been completed.
        /// </summary>
        Pending
    }
}
