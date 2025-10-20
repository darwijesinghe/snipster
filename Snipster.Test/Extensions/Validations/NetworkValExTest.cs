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
        public void IsValidIPv4_ShouldIdentify_ValidAndInvalid_IPv4_Addresses()
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

        /// <summary>
        /// Test IsValidIPv6 method to ensure it correctly identifies valid and invalid IPv6 addresses.
        /// </summary>
        [TestMethod]
        public void IsValidIPv6_ShouldIdentify_ValidAndInvalid_IPv6_Addresses()
        {
            // Arrange
            string validIPv6   = "2001:0db8:85a3:0000:0000:8a2e:0370:7334";
            string invalidIPv6 = "2001:0db8:85a3:0000:0000:8a2e:0370:zzzz";

            // Act
            bool isValidIPv6Result   = validIPv6.IsValidIPv6();
            bool isInvalidIPv6Result = invalidIPv6.IsValidIPv6();

            // Assert
            Assert.IsTrue(isValidIPv6Result);
            Assert.IsFalse(isInvalidIPv6Result);
        }

        /// <summary>
        /// Test IsValidWebAddress method to ensure it correctly identifies valid and invalid web addresses.
        /// </summary>
        [TestMethod]
        public void IsValidWebAddress_ShouldIdentify_ValidAndInvalid_Web_Addresses()
        {
            // Arrange
            string validWebAddress   = "https://www.example.com";
            string invalidWebAddress = "ftp://www.example.com";

            // Act
            bool isValidWebAddressResult   = validWebAddress.IsValidWebAddress();
            bool isInvalidWebAddressResult = invalidWebAddress.IsValidWebAddress();

            // Assert
            Assert.IsTrue(isValidWebAddressResult);
            Assert.IsFalse(isInvalidWebAddressResult);
        }
    }
}
