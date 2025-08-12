using Snipster.Library.Extensions.Validations;

namespace Snipster.Test.Extensions.Validations
{
    /// <summary>
    /// Unit tests to validate the functionality of the JsonValEx class.
    /// </summary>
    [TestClass]
    public class JsonValExTest
    {
        /// <summary>
        /// Test IsValidJson method to ensure it correctly identifies valid and invalid email formats.
        /// </summary>
        [TestMethod]
        public void IsValidJson_ShouldValidateValidEmailAddress()
        {
            // Arrange
            string validJson = "{\"name\":\"John\", \"age\":30, \"city\":\"New York\"}";
            string invalidJson = "{name:John, age:30, city:New York}";

            // Act
            bool isValidJsonResult = validJson.IsValidJson();
            bool isInvalidJsonResult = invalidJson.IsValidJson();

            // Assert
            Assert.IsTrue(isValidJsonResult);
            Assert.IsFalse(isInvalidJsonResult);
        }
    }
}
