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

        /// <summary>
        /// Gets or sets the age.
        /// </summary>
        public int Age           { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether the user is a member.
        /// </summary>
        public bool IsMember     { get; set; }
        /// <summary>
        /// Gets or sets the join date.
        /// </summary>
        public DateTime JoinDate { get; set; }
        /// <summary>
        /// Gets or sets the salary.
        /// </summary>
        public double Salary     { get; set; }
        /// <summary>
        /// Gets or sets the commission value.
        /// </summary>
        public double Commission { get; set; }
    }
}
