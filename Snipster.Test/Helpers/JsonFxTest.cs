using Newtonsoft.Json;
using Snipster.Library.Helpers;

namespace Snipster.Test.Helpers
{
    /// <summary>
    /// Unit tests to validate the functionality of the JsonFx class.
    /// </summary>
    [TestClass]
    public class JsonFxTest
    {
        /// <summary>
        /// Tests the Minify method to ensure it correctly minifies a JSON string.
        /// </summary>
        [TestMethod]
        public void Minify_ShouldCorrectlyMinifyJsonString()
        {
            // Arrange
            string json     = "{ \"name\": \"John\", \"age\": 30, \"city\": \"New York\" }";
            string expected = "{\"name\":\"John\",\"age\":30,\"city\":\"New York\"}";

            // Act
            string minifiedJson = JsonFx.Minify(json);

            // Assert
            Assert.AreEqual(expected, minifiedJson);
        }

        /// <summary>
        /// Tests the Prettify method to ensure it correctly formats a JSON string for readability.
        /// </summary>
        [TestMethod]
        public void Prettify_ShouldCorrectlyPrettifyJsonString()
        {
            // Arrange
            string json     = "{\"name\":\"John\",\"age\":30,\"city\":\"New York\"}";
            string expected = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(json), Formatting.Indented);

            // Act
            string prettifiedJson = JsonFx.Prettify(json);

            // Assert
            Assert.AreEqual(expected, prettifiedJson);
        }
    }
}
