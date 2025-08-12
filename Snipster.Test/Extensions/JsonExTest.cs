using Snipster.Library.Extensions;
using Snipster.Test.Models;

namespace Snipster.Test.Extensions
{
    /// <summary>
    /// Unit tests for the JsonEx class, which provides extensions for working with JSON data.
    /// </summary>
    [TestClass]
    public class JsonExTest
    {
        /// <summary>
        /// Tests the ToJson method to ensure it converts an object to a JSON string correctly.
        /// </summary>
        [TestMethod]
        public void ToJson_ShouldConvertObjectToJson()
        {
            // Arrange
            var obj      = new { Name = "Test", Value = 123 };
            var expected = "{\"Name\":\"Test\",\"Value\":123}";

            // Act
            var json = obj.ToJson();

            // Assert
            Assert.AreEqual(expected, json);
        }

        /// <summary>
        /// Tests the FromJson method to ensure it converts a JSON string to an object correctly.
        /// </summary>
        [TestMethod]
        public void FromJson_ShouldConvertJsonToObject()
        {
            // Arrange
            var json     = "{\"Name\":\"Test\",\"Value\":123}";
            var expected = new { Name = "Test", Value = 123 };

            // Act
            var obj = json.FromJson<TestObject>();

            // Assert
            Assert.IsNotNull(obj);
            Assert.AreEqual(expected.Name, obj?.Name?.ToString());
            Assert.AreEqual(expected.Value, obj?.Value);
        }

        /// <summary>
        /// Tests the FromJson method with an invalid JSON string to ensure it returns default value.
        /// </summary>
        [TestMethod]
        public void FromJson_InvalidJson_ShouldReturnDefault()
        {
            // Arrange
            var invalidJson = "{InvalidJson}";

            // Act
            var obj = invalidJson.FromJson<dynamic>();

            // Assert
            Assert.IsNull(obj);
        }
    }
}
