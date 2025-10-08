namespace Snipster.Test.Models
{
    /// <summary>
    /// Represents a test object used for unit testing purposes.
    /// </summary>
    public class TestObject
    {
        /// <summary>
        /// Gets or sets the unique identifier for the test object.
        /// </summary>
        public int Id            { get; set; }

        /// <summary>
        /// Gets or sets the name of the test object.
        /// </summary>
        public string? Name      { get; set; }

        /// <summary>
        /// Gets or sets the value of the test object.
        /// </summary>
        public int Value         { get; set; }

        // Extra -----------------------------

        public int Age           { get; set; }
        public bool IsMember     { get; set; }
        public DateTime JoinDate { get; set; }
        public double Salary     { get; set; }
        public double Commission { get; set; }
    }
}
