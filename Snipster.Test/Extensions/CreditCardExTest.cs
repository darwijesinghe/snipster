using Snipster.Library.Enums;
using Snipster.Library.Extensions;

namespace Snipster.Test.Extensions
{
    /// <summary>
    /// Unit tests to validate the functionality of the <see cref="CreditCardEx"/> class.
    /// </summary>
    [TestClass]
    public class CreditCardExTest
    {
        /// <summary>
        /// Tests the <see cref="CreditCardEx.GetCreditCardType"/> method that correctly identifies supported card types.
        /// </summary>
        [DataTestMethod]
        [DataRow("4111111111111111", CardType.Visa)]
        [DataRow("5500000000000004", CardType.MasterCard)]
        [DataRow("340000000000009", CardType.AmericanExpress)]
        [DataRow("6011000000000004", CardType.Discover)]
        [DataRow("3530111333300000", CardType.JCB)]
        [DataRow("30000000000004", CardType.DinersClub)]
        public void GetCreditCardType_Should_Identify_Supported_Cards(string number, CardType expected)
        {
            // Act
            var result = number.GetCreditCardType();

            // Assert
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Tests the <see cref="CreditCardEx.GetCreditCardType"/> method that ignores spaces in the card number.
        /// </summary>
        [TestMethod]
        public void GetCreditCardType_Should_IgnoreSpaces()
        {
            // Arrange
            var number = "4111 1111 1111 1111";

            // Act
            var result = number.GetCreditCardType();

            // Assert
            Assert.AreEqual(CardType.Visa, result);
        }

        /// <summary>
        /// Tests the <see cref="CreditCardEx.GetCreditCardType"/> method that returns <see cref="CardType.Unknown"/> for invalid numeric formats.
        /// </summary>
        [DataTestMethod]
        [DataRow("abcd1234")]
        [DataRow("4111-1111-1111-1111")]
        [DataRow("123456")]
        public void GetCreditCardType_Should_Return_Unknown_For_InvalidFormat(string number)
        {
            // Act
            var result = number.GetCreditCardType();

            // Assert
            Assert.AreEqual(CardType.Unknown, result);
        }

        /// <summary>
        /// Tests the <see cref="CreditCardEx.GetCreditCardType"/> method that returns <see cref="CardType.Unknown"/> for unsupported prefixes.
        /// </summary>
        [DataTestMethod]
        [DataRow("9999999999999999")]
        [DataRow("7000000000000000")]
        public void GetCreditCardType_Should_Return_Unknown_For_Unsupported_Prefixes(string number)
        {
            // Act
            var result = number.GetCreditCardType();

            // Assert
            Assert.AreEqual(CardType.Unknown, result);
        }

        /// <summary>
        /// Tests the <see cref="CreditCardEx.GetCreditCardType"/> method that returns <see cref="CardType.Unknown"/> when the input is <see langword="null"/> or whitespace.
        /// </summary>
        [DataTestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("   ")]
        public void GetCreditCardType_Should_Return_Unknown_When_Input_IsNullOrWhitespace(string number)
        {
            // Act
            var result = number.GetCreditCardType();

            // Assert
            Assert.AreEqual(CardType.Unknown, result);
        }
    }
}
