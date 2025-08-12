using Snipster.Library.Extensions.Validations;

namespace Snipster.Test.Extensions.Validations
{
    /// <summary>
    /// Unit tests to validate the functionality of the StringValEx class.
    /// </summary>
    [TestClass]
    public class StringValExTest
    {
        /// <summary>
        /// Test ContainsIgnoreCase method to ensure it correctly identifies substrings in a case-insensitive manner.
        /// </summary>
        [TestMethod]
        public void IsContainsIgnoreCase_ShouldIdentifySubstring_In_CaseSensitiveManner()
        {
            // Arrange
            string mainString       = "Hello World";
            string validSubstring   = "world";
            string invalidSubstring = "planet";

            // Act
            bool containsValidSubstring   = mainString.IsContainsIgnoreCase(validSubstring);
            bool containsInvalidSubstring = mainString.IsContainsIgnoreCase(invalidSubstring);

            // Assert
            Assert.IsTrue(containsValidSubstring);
            Assert.IsFalse(containsInvalidSubstring);
        }

        /// <summary>
        /// Test IsValidSriLankanPhone method to ensure it correctly identifies valid and invalid Sri Lankan phone numbers.
        /// </summary>
        [TestMethod]
        public void IsValidSriLankanPhone_ShouldIdentifyValidAndInvalidNumber()
        {
            // Arrange
            string validPhone   = "0712345678";
            string invalidPhone = "123456";

            // Act
            bool isValidPhoneResult   = validPhone.IsValidSriLankanPhone();
            bool isInvalidPhoneResult = invalidPhone.IsValidSriLankanPhone();

            // Assert
            Assert.IsTrue(isValidPhoneResult);
            Assert.IsFalse(isInvalidPhoneResult);
        }

        /// <summary>
        /// Test IsValidInternationalPhone method to ensure it correctly identifies valid and invalid international phone numbers.
        /// </summary>
        [TestMethod]
        public void IsValidInternationalPhone_ShouldIdentifyValidAndInvalidNumbers()
        {
            // Arrange
            string validPhone   = "+941234567890";
            string invalidPhone = "12345";

            // Act
            bool isValidPhoneResult   = validPhone.IsValidInternationalPhone();
            bool isInvalidPhoneResult = invalidPhone.IsValidInternationalPhone();

            // Assert
            Assert.IsTrue(isValidPhoneResult);
            Assert.IsFalse(isInvalidPhoneResult);
        }

        /// <summary>
        /// Test IsNumeric method to ensure it correctly identifies numeric strings.
        /// </summary>
        [TestMethod]
        public void IsNumeric_ShouldIdentifyNumericStrings()
        {
            // Arrange
            string validNumeric   = "123456";
            string invalidNumeric = "123abc";

            // Act
            bool isValidNumericResult   = validNumeric.IsNumeric();
            bool isInvalidNumericResult = invalidNumeric.IsNumeric();

            // Assert
            Assert.IsTrue(isValidNumericResult);
            Assert.IsFalse(isInvalidNumericResult);
        }

        /// <summary>
        /// Test IsAlphabetic method to ensure it correctly identifies alphabetic strings.
        /// </summary>
        [TestMethod]
        public void IsAlphabetic_ShouldIdentifyAlphabeticStrings()
        {
            // Arrange
            string validAlphabetic   = "Hello";
            string invalidAlphabetic = "Hello123";

            // Act
            bool isValidAlphabeticResult   = validAlphabetic.IsAlphabetic();
            bool isInvalidAlphabeticResult = invalidAlphabetic.IsAlphabetic();

            // Assert
            Assert.IsTrue(isValidAlphabeticResult);
            Assert.IsFalse(isInvalidAlphabeticResult);
        }

        /// <summary>
        /// Test IsAlphanumeric method to ensure it correctly identifies alphanumeric strings.
        /// </summary>
        [TestMethod]
        public void IsAlphanumeric_ShouldIdentifyAlphanumericStrings()
        {
            // Arrange
            string validAlphanumeric   = "Hello123";
            string invalidAlphanumeric = "Hello@123";

            // Act
            bool isValidAlphanumericResult   = validAlphanumeric.IsAlphanumeric();
            bool isInvalidAlphanumericResult = invalidAlphanumeric.IsAlphanumeric();

            // Assert
            Assert.IsTrue(isValidAlphanumericResult);
            Assert.IsFalse(isInvalidAlphanumericResult);
        }
    }
}
