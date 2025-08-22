using Snipster.Library.Extensions.Validations;

namespace Snipster.Test.Extensions.Validations
{
    /// <summary>
    /// Unit tests to validate the functionality of the NetworkValEx class.
    /// </summary>
    [TestClass]
    public class NetworkValExTest
    {
        /// <summary>
        /// Test IsValidIPv4 method to ensure it correctly identifies valid and invalid IPv4 addresses.
        /// </summary>
        [TestMethod]
        public void IsValidIPv4_ShouldIdentifyValidAndInvalid_IPv4_Addresses()
        {
            // Arrange
            string validIPv4   = "192.168.1.1";
            string invalidIPv4 = "999.999.999.999";

            // Act
            bool isValidIPv4Result   = validIPv4.IsValidIPv4();
            bool isInvalidIPv4Result = invalidIPv4.IsValidIPv4();

            // Assert
            Assert.IsTrue(isValidIPv4Result);
            Assert.IsFalse(isInvalidIPv4Result);
        }
    }
}
