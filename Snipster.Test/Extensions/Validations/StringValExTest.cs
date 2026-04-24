using Snipster.Library.Extensions.Validations;

namespace Snipster.Test.Extensions.Validations
{
    /// <summary>
    /// Unit tests to validate the functionality of the <see cref="StringValEx"/> class.
    /// </summary>
    [TestClass]
    public class StringValExTest
    {
        /// <summary>
        /// Test <see cref="StringValEx.IsContainsIgnoreCase"/> method to ensure it correctly identifies substrings in a case-insensitive manner.
        /// </summary>
        [DataTestMethod]

        // Valid cases
        [DataRow("Hello World", "world", true)]
        [DataRow("Hello World", "WORLD", true)]
        [DataRow("Hello World", "hello", true)]
        [DataRow("Hello World", "test", false)]
        [DataRow("Hello World", "", true)]
        [DataRow("", "", true)]

        // Invalid cases
        [DataRow("", "a", false)]
        [DataRow(null, "test", false)]
        [DataRow("Test", null, false)]
        public void IsContainsIgnoreCase_ShouldWorkCorrectly(string source, string toCheck, bool expected)
        {
            // Act
            var result = source.IsContainsIgnoreCase(toCheck);

            // Assert
            Assert.AreEqual(expected, result, $"Failed for: {source}");
        }

        /// <summary>
        /// Test <see cref="StringValEx.IsValidPhoneNumber"/> method to ensure it correctly identifies valid and invalid phone numbers.
        /// </summary>
        [DataTestMethod]

        // Valid cases
        [DataRow("+94702293007", null, true, "+94702293007")]
        [DataRow("+94 70 229 3007", null, true, "+94702293007")]
        [DataRow("0702293007", "LK", true, "+94702293007")]
        [DataRow("702293007", "LK", true, "+94702293007")]

        [DataRow("+12025550125", null, true, "+12025550125")]
        [DataRow("+1 202 555 0125", null, true, "+12025550125")]
        [DataRow("(202) 555-0125", "US", true, "+12025550125")]
        [DataRow("2025550125", "US", true, "+12025550125")]

        [DataRow("+44 7911 123456", null, true, "+447911123456")]
        [DataRow("07911 123456", "GB", true, "+447911123456")]
        [DataRow("7911123456", "GB", true, "+447911123456")]

        // Invalid cases
        [DataRow("+123", null, false, null)]
        [DataRow("abcdef", "US", false, null)]
        [DataRow("", "US", false, null)]
        [DataRow(null, "US", false, null)]
        [DataRow("+9999999999999999", null, false, null)] // invalid country code
        [DataRow("0791112345", "GB", false, null)]
        [DataRow("202555012", "US", false, null)]
        [DataRow("0702293007", null, false, null)]
        public void IsValidPhoneNumber_ShouldHandleAllCases(string input, string region, bool expectedResult, string expectedFormatted)
        {
            // Act
            var result = input.IsValidPhoneNumber(region, out var formatted);

            // Assert
            Assert.AreEqual(expectedResult, result, $"Failed for: {input}");
            Assert.AreEqual(expectedFormatted, formatted, $"Failed for: {input}");
        }

        /// <summary>
        /// Test <see cref="StringValEx.IsNumeric"/> method to ensure it correctly identifies numeric strings.
        /// </summary>
        [DataTestMethod]

        // Valid cases
        [DataRow("123456", true)]
        [DataRow("0", true)]
        [DataRow("00123", true)]

        // Invalid cases
        [DataRow("", false)]
        [DataRow(null, false)]
        [DataRow("123a", false)]
        [DataRow("12 34", false)]
        [DataRow("12.34", false)]
        [DataRow("+123", false)]
        [DataRow("１２３", false)] // Unicode digits
        public void IsNumeric_ShouldValidate_ASCII_DigitsOnly(string input, bool expected)
        {
            // Act
            var result = input.IsNumeric();

            // Assert
            Assert.AreEqual(expected, result, $"Failed for: {input}");
        }

        /// <summary>
        /// Test <see cref="StringValEx.IsAlphabetic"/> method to ensure it correctly identifies alphabetic strings.
        /// </summary>
        [DataTestMethod]

        // Valid cases
        [DataRow("abc", true)]
        [DataRow("ABC", true)]
        [DataRow("AbCdEf", true)]

        // Invalid cases
        [DataRow("", false)]
        [DataRow(null, false)]
        [DataRow("abc123", false)]
        [DataRow("abc def", false)]
        [DataRow("éclair", false)]
        [DataRow("über", false)]
        [DataRow("abc!", false)]
        public void IsAlphabetic_ShouldAllowEnglishLettersOnly(string input, bool expected)
        {
            // Act
            var result = input.IsAlphabetic();

            // Assert
            Assert.AreEqual(expected, result, $"Failed for: {input}");
        }

        /// <summary>
        /// Test <see cref="StringValEx.IsAlphanumeric"/> method to ensure it correctly identifies alphanumeric strings.
        /// </summary>
        [DataTestMethod]

        // Valid cases
        [DataRow("abc123", true)]
        [DataRow("ABC123", true)]
        [DataRow("a1B2c3", true)]
        [DataRow("123", true)]
        [DataRow("abc", true)]

        // Invalid cases
        [DataRow("", false)]
        [DataRow(null, false)]
        [DataRow("abc_123", false)]
        [DataRow("abc-123", false)]
        [DataRow("abc 123", false)]
        [DataRow("abc!", false)]
        [DataRow("ümlaut1", false)]
        [DataRow("Hello@123", false)]
        public void IsAlphanumeric_ShouldAllowEnglishLetters_And_DigitsOnly(string input, bool expected)
        {
            // Act
            var result = input.IsAlphanumeric();

            // Assert
            Assert.AreEqual(expected, result, $"Failed for: {input}");
        }
    }
}
