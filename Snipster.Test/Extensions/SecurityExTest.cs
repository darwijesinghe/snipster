using Snipster.Library.Extensions;

namespace Snipster.Test.Extensions
{
    /// <summary>
    /// Unit tests to validate the functionality of the SecurityEx class.
    /// </summary>
    [TestClass]
    public class SecurityExTest
    {
        /// <summary>
        /// Tests the ToSha256 method to ensure it generates a SHA256 hash from a string.
        /// </summary>
        [TestMethod]
        public void ToSha256_ShouldGeneratesSHA256HashFromString()
        {
            // Arrange
            string input        = "Hello, World!";
            string expectedHash = "dffd6021bb2bd5b0af676290809ec3a53191dd81c7f70a4b28688a362182986f";

            // Act
            string hash = input.ToSha256();

            // Assert
            Assert.IsNotNull(hash);
            Assert.AreEqual(expectedHash, hash);
        }
    }
}
