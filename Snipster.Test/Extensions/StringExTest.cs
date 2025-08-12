using Snipster.Library.Extensions;
using Snipster.Test.Models;

namespace Snipster.Test.Extensions
{
    /// <summary>
    /// Unit tests to validate the functionality of the StringEx class.
    /// </summary>
    [TestClass]
    public class StringExTest
    {
        /// <summary>
        /// Tests the CapitalizeFirst method to ensure it capitalizes the first letter of a string.
        /// </summary>
        [TestMethod]
        public void CapitalizeFirst_ShouldCapitalizeFirstLetter()
        {
            // Arrange
            var input    = "hello";
            var expected = "Hello";

            // Act
            var result = input.CapitalizeFirst();

            // Assert
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Tests the ToTitleCase method to ensure it converts a string to title case.
        /// </summary>
        [TestMethod]
        public void ToTitleCase_ShouldConvertToTitleCase()
        {
            // Arrange
            var input    = "hello world";
            var expected = "Hello World";

            // Act
            var result = input.ToTitleCase();

            // Assert
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Tests the OnlyDigits method to ensure it extracts only numeric characters from a string.
        /// </summary>
        [TestMethod]
        public void OnlyDigits_ShouldContainOnlyNumericCharacters()
        {
            // Arrange
            var input    = "123@abc";
            var expected = "123";

            // Act
            var result = input.OnlyDigits();

            // Assert
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Tests the Truncate method to ensure it truncates a string to a specified length and appends ellipsis if necessary.
        /// </summary>
        [TestMethod]
        public void Truncate_ShouldTruncateInputToSpecifiedLength()
        {
            // Arrange
            var input     = "Hello world from me";
            var maxLength = 10;
            var expected  = "Hello worl...";

            // Act
            var result = input.Truncate(maxLength);

            // Assert
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Tests the Slugify method to ensure it converts a string into a URL-friendly slug format.
        /// </summary>
        [TestMethod]
        public void Slugify_ShouldSlugifyTheInput()
        {
            // Arrange
            var input    = "Hello world from me";
            var expected = "hello-world-from-me";

            // Act
            var result = input.Slugify();

            // Assert
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Tests the ToBase64 method to ensure it converts a string to Base64 encoding.
        /// </summary>
        [TestMethod]
        public void ToBase64_ShouldConvertInputToBase64()
        {
            // Arrange
            var input    = "Hello world from me";
            var expected = "SGVsbG8gd29ybGQgZnJvbSBtZQ==";

            // Act
            var result = input.ToBase64();

            // Assert
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Tests the FromBase64 method to ensure it decodes a Base64 encoded string back to its original form.
        /// </summary>
        [TestMethod]
        public void FromBase64_ShouldDecodeBase64EncodedString()
        {
            // Arrange
            var input    = "SGVsbG8gd29ybGQgZnJvbSBtZQ==";
            var expected = "Hello world from me";

            // Act
            var result = input.FromBase64();

            // Assert
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Tests the OrDefault method to ensure it returns a default value if the input string is null or empty.
        /// </summary>
        [TestMethod]
        public void OrDefault_ShouldReturnDefaultValueIfInputIsNullOrEmpty()
        {
            // Arrange
            string? input    = null;
            var defaultValue = "Default Value";
            var expected     = "Default Value";

            // Act
            var result = input.OrDefault(defaultValue);

            // Assert
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Tests the StripHtmlTags method to ensure it removes HTML tags from a string.
        /// </summary>
        [TestMethod]
        public void StripHtmlTags_ShouldStripHtmlTagsFromInput()
        {
            // Arrange
            var input    = "<p>Hello <strong>world</strong> from me</p>";
            var expected = "Hello world from me";

            // Act
            var result = input.StripHtmlTags();

            // Assert
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Tests the SanitizeAlphanumeric method to ensure it removes non-alphanumeric characters from a string.
        /// </summary>
        [TestMethod]
        public void SanitizeAlphanumeric_ShouldRemoveNonAlphanumericCharacters()
        {
            // Arrange
            var input    = "Hello@123!";
            var expected = "Hello123";

            // Act
            var result = input.SanitizeAlphanumeric();

            // Assert
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Tests the RemoveSpecialCharacters method to ensure it removes special characters except spaces from a string.
        /// </summary>
        [TestMethod]
        public void RemoveSpecialCharacters_ShouldRemoveSpecialCharactersExceptSpaces()
        {
            // Arrange
            var input    = "Hello@123! World";
            var expected = "Hello123 World";

            // Act
            var result = input.RemoveSpecialCharacters();

            // Assert
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Tests the ToCamelCase method to ensure it converts a string to camel case format.
        /// </summary>
        [TestMethod]
        public void ToCamelCase_ShouldConvertToCamelCase()
        {
            // Arrange
            var input    = "hello world";
            var expected = "helloWorld";

            // Act
            var result = input.ToCamelCase();

            // Assert
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Tests the ToPascalCase method to ensure it converts a string to Pascal case format.
        /// </summary>
        [TestMethod]
        public void ToPascalCase_ShouldConvertToPascalCase()
        {
            // Arrange
            var input    = "hello world";
            var expected = "HelloWorld";

            // Act
            var result = input.ToPascalCase();

            // Assert  
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Tests the ToKebabCase method to ensure it converts a string to kebab case format.
        /// </summary>
        [TestMethod]
        public void ToKebabCase_ShouldConvertToKebabCase()
        {
            // Arrange
            var input    = "Hello World";
            var expected = "hello-world";

            // Act
            var result = input.ToKebabCase();

            // Assert
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Tests the RemoveWhitespace method to ensure it removes all whitespace characters from a string.
        /// </summary>
        [TestMethod]
        public void RemoveWhitespace_ShouldRemoveAllWhitespace()
        {
            // Arrange
            var input    = "Hello   World";
            var expected = "HelloWorld";

            // Act  
            var result = input.RemoveWhitespace();

            // Assert
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Tests the NormalizeSpaces method to ensure it normalizes multiple spaces to a single space.
        /// </summary>
        [TestMethod]
        public void NormalizeSpaces_ShouldNormalizeSpaces()
        {
            // Arrange
            var input    = "  Hello   World  ";
            var expected = "Hello World";

            // Act
            var result = input.NormalizeSpaces();

            // Assert
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Tests the GetDescription method to ensure it retrieves the 
        /// description attribute of an enum value. If the enum value does not have a description, it should return the enum name.
        /// </summary>
        [TestMethod]
        public void GetDescription_ShouldReturnCorrectDescription()
        {
            // Arrange
            var input1    = Status.Success;
            var input2    = Status.Pending;
            var expected1 = "Operation successful";
            var expected2 = "Pending";

            // Act
            var result1 = input1.GetDescription();
            var result2 = input2.GetDescription();

            // Assert
            Assert.AreEqual(expected1, result1);
            Assert.AreEqual(expected2, result2);
        }

        [TestMethod]
        public void ToCleanQueryString_ShouldReturnCleanQueryString()
        {
            // Arrange: simulate a SQL query with BOM at the start
            var bomChar  = "\uFEFF";
            var input    = bomChar + "SELECT * FROM Customers WHERE Id = 1";
            var expected = "SELECT * FROM Customers WHERE Id = 1";

            // Act
            var result = input.ToCleanQueryString();

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
