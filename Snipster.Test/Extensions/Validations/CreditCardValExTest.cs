using Snipster.Library.Extensions.Validations;

namespace Snipster.Test.Extensions.Validations
{
    /// <summary>
    /// Unit tests to validate the functionality of the CreditCardValEx class.
    /// </summary>
    [TestClass]
    public class CreditCardValExTest
    {
        /// <summary>
        /// Test to validate various credit card numbers.
        /// </summary>
        [TestMethod]
        public void IsValidCreditCard_ShouldValidateVariousCreditCardNumbers()
        {
            // Arrange
            var validCreditCardNumbers = new List<string>
            {
                "4111111111111111",     // Visa
                "4111 1111 1111 1111",  // Visa with spaces
                "5500000000000004",     // MasterCard
                "340000000000009",      // American Express
                "6011000000000012"      // Discover
            };

            // Act
            var results = validCreditCardNumbers.Select(x => x.IsValidCreditCard()).ToList();

            // Assert
            Assert.IsNotNull(results);
            Assert.IsTrue(results.All(result => result));
            Assert.AreEqual(validCreditCardNumbers.Count, results.Count);
        }

        /// <summary>
        /// Tests IsValidCreditCard method to ensure it returns false for invalid credit card numbers.
        /// </summary>
        [DataTestMethod]
        [DataRow("1234567890123456")]       // Invalid Luhn
        [DataRow("4111111111111")]          // Too short
        [DataRow("41111111111111111111")]   // Too long
        [DataRow("abcd efgh ijkl mnop")]    // Non-digit characters
        [DataRow("")]                       // Empty string
        [DataRow("    ")]                   // Whitespace only
        [DataRow("4111-1111-1111-1111")]    // Visa with dashes
        public void IsValidCreditCard_ShouldReturnFalseForInvalidCards(string cardNumber)
        {
            // Act
            bool result = cardNumber.IsValidCreditCard();

            // Assert
            Assert.IsFalse(result);
        }
    }
}