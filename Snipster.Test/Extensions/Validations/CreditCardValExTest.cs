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
                "4111111111111111", // Visa
                "5500000000000004", // MasterCard
                "340000000000009",  // American Express
                "6011000000000012"  // Discover
            };

            // Act
            var results = validCreditCardNumbers.Select(x => x.IsValidCreditCard()).ToList();

            // Assert
            Assert.IsNotNull(results);
            Assert.IsTrue(results.All(result => result));
            Assert.AreEqual(validCreditCardNumbers.Count, results.Count);
        }
    }
}
