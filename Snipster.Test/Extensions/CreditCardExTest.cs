using Snipster.Library.Extensions;

namespace Snipster.Test.Extensions
{
    /// <summary>
    /// Unit tests to validate the functionality of the CreditCardEx class.
    /// </summary>
    [TestClass]
    public class CreditCardExTest
    {
        /// <summary>
        /// Tests the GetCreditCardType method for a valid Visa card number.
        /// </summary>
        [TestMethod]
        public void GetCreditCardType_ShouldReturnVisa_ForValidVisaCardNumber()
        {
            // Arrange
            string visaCardNumber = "4111111111111111";

            // Act
            string result = visaCardNumber.GetCreditCardType();

            // Assert
             
            Assert.AreEqual("Visa", result);
        }

        /// <summary>
        /// Tests the GetCreditCardType method for a valid MasterCard number.
        /// </summary>
        [TestMethod]
        public void GetCreditCardType_ShouldReturnMasterCard_ForValidMasterCardNumber()
        {
            // Arrange
            string masterCardNumber = "5555555555554444";

            // Act
            string result = masterCardNumber.GetCreditCardType();

            // Assert
            Assert.AreEqual("MasterCard", result);
        }

        /// <summary>
        /// Tests the GetCreditCardType method for a valid American Express card number.
        /// </summary>
        [TestMethod]
        public void GetCreditCardType_ShouldReturnAmericanExpress_ForValidAmexCardNumber()
        {
            // Arrange
            string amexCardNumber = "378282246310005";

            // Act
            string result = amexCardNumber.GetCreditCardType();

            // Assert
            Assert.AreEqual("American Express", result);
        }

        /// <summary>
        /// Tests the GetCreditCardType method for a valid Discover card number.
        /// </summary>
        [TestMethod]
        public void GetCreditCardType_ShouldReturnDiscover_ForValidDiscoverCardNumber()
        {
            // Arrange
            string discoverCardNumber = "6011111111111117";

            // Act
            string result = discoverCardNumber.GetCreditCardType();

            // Assert
            Assert.AreEqual("Discover", result);
        }

        /// <summary>
        /// Tests the GetCreditCardType method for a valid JCB card number.
        /// </summary>
        [TestMethod]
        public void GetCreditCardType_ShouldReturnJCB_ForValidJCBCardNumber()
        {
            // Arrange
            string jcbCardNumber = "3530111333300000";

            // Act
            string result = jcbCardNumber.GetCreditCardType();

            // Assert
            Assert.AreEqual("JCB", result);
        }

        /// <summary>
        /// Tests the GetCreditCardType method for a valid Diners Club card number.
        /// </summary>
        [TestMethod]
        public void GetCreditCardType_ShouldReturnDinersClub_ForValidDinersClubCardNumber()
        {
            // Arrange
            string dinersClubCardNumber = "30569309025904";

            // Act
            string result = dinersClubCardNumber.GetCreditCardType();

            // Assert
            Assert.AreEqual("Diners Club", result);
        }

        /// <summary>
        /// Tests the GetCreditCardType method for an invalid card number.
        /// </summary>
        [TestMethod]
        public void GetCreditCardType_ShouldReturnUnknown_ForInvalidCardNumber()
        {
            // Arrange
            string invalidCardNumber = "1234567890123456";
            string expected          = "Unknown";

            // Act
            string result = invalidCardNumber.GetCreditCardType();

            // Assert
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Tests the GetCreditCardType method for a null card number.
        /// </summary>
        [TestMethod]
        public void GetCreditCardType_ShouldReturnUnknown_ForEmptyCardNumber()
        {
            // Arrange
            string emptyCardNumber = "";
            string expected        = "Unknown";

            // Act
            string result = emptyCardNumber.GetCreditCardType();

            // Assert
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Tests the GetCreditCardType method for a non-numeric card number.
        /// </summary>
        [TestMethod]
        public void GetCreditCardType_ShouldReturnUnknown_ForNonNumericCardNumber()
        {
            // Arrange
            string nonNumericCardNumber = "abcd1234";
            string expected             = "Unknown";

            // Act
            string result = nonNumericCardNumber.GetCreditCardType();

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
