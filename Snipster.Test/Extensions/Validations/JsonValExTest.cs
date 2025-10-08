using Snipster.Library.Extensions.Validations;

namespace Snipster.Test.Extensions.Validations
{
    /// <summary>
    /// Unit tests to validate the functionality of the JsonValEx class.
    /// </summary>
    [TestClass]
    public class JsonValExTest
    {
        /// <summary>s
        /// Test IsValidJson method to ensure it correctly identifies valid JSON strings.
        /// </summary>
        [TestMethod]
        public void IsValidJson_ShouldValidateValidJsonStrings()
        {
            // Arrange
            string validJson = @"{""name"":""John"", ""age"":30, ""city"":""New York""}";

            // Act
            bool isValidJsonResult = validJson.IsValidJson();

            // Assert
            Assert.IsTrue(isValidJsonResult);
        }

        /// <summary>s
        /// Test IsValidJson method to ensure it correctly identifies invalid JSON strings.
        /// </summary>
        [TestMethod]
        public void IsValidJson_ShouldValidateInvalidJsonStrings()
        {
            // Arrange
            string invalidJson = @"{name:""John"", age:30, city:""New York""";

            // Act
            bool isValidJsonResult = invalidJson.IsValidJson();

            // Assert
            Assert.IsFalse(isValidJsonResult);
        }

        /// <summary>s
        /// Test IsValidJson method to ensure it correctly identifies array JSON strings.
        /// </summary>
        [TestMethod]
        public void IsValidJson_ShouldValidateArrayJsonStrings()
        {
            // Arrange
            string arrayJson = @"[""apple"", ""banana"", ""cherry""]";

            // Act
            bool isValidJsonResult = arrayJson.IsValidJson();

            // Assert
            Assert.IsTrue(isValidJsonResult);
        }

        /// <summary>s
        /// Test IsValidJson method to ensure it correctly identifies the nested JSON strings with arrays.
        /// </summary>
        [TestMethod]
        public void IsValidJson_ShouldValidateNestedJsonStringsWithArray()
        {
            // Arrange
            string nestedJson = @"{""name"":""John"", ""age"":30, ""cars"": [""Ford"", ""BMW"", ""Fiat""]}";

            // Act
            bool isValidJsonResult = nestedJson.IsValidJson();

            // Assert
            Assert.IsTrue(isValidJsonResult);
        }
    }
}
