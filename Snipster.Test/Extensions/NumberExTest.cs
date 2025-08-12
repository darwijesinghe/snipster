using Snipster.Library.Extensions;

namespace Snipster.Test.Extensions
{
    /// <summary>
    /// Unit tests to validate the functionality of the NumberEx class.
    /// </summary>
    [TestClass]
    public class NumberExTest
    {
        /// <summary>
        /// Tests the ToIntSafe method to ensure it converts a string to an integer or returns a default value if conversion fails.
        /// </summary>
        [TestMethod]
        public void ToIntSafe_ShouldConvertToIntOrDefault()
        {
            // Arrange
            var input        = "123";
            var defaultValue = 0;
            var expected     = 123;

            // Act
            var result = input.ToIntSafe(defaultValue);

            // Assert
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Tests the ToDoubleSafe method to ensure it converts a string to a double or returns a default value if conversion fails.
        /// </summary>
        [TestMethod]
        public void ToDoubleSafe_ShouldConvertToDoubleOrDefault()
        {
            // Arrange
            var input        = "123.45";
            var defaultValue = 0.0;
            var expected     = 123.45;

            // Act
            var result = input.ToDoubleSafe(defaultValue);

            // Assert
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Tests the ToOrdinal method to ensure it converts an integer to its ordinal representation as a string (e.g., "1st", "2nd", "3rd", "4th", etc.).
        /// </summary>
        [TestMethod]
        public void ToOrdinal_ShouldReturnOrdinalRepresentation()
        {
            // Arrange
            var input    = 10;
            var expected = "10th";

            // Act
            var result = input.ToOrdinal();

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
