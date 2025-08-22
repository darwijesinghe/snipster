using Snipster.Library.Extensions.Validations;

namespace Snipster.Test.Extensions.Validations
{
    /// <summary>
    /// Unit tests to validate the functionality of the SecurityValEx class.
    /// </summary>
    [TestClass]
    public class SecurityValExTest
    {
        /// <summary>
        /// Test IsValidEmail method to ensure it correctly identifies valid and invalid email formats.
        /// </summary>
        [TestMethod]
        public void IsValidEmail_ShouldValidateValidEmailAddress()
        {
            // Arrange
            string validEmail   = "test@example.com";
            string invalidEmail = "invalid-email";

            // Act
            bool isValidEmailResult   = validEmail.IsValidEmail();
            bool isInvalidEmailResult = invalidEmail.IsValidEmail();

            // Assert
            Assert.IsTrue(isValidEmailResult);
            Assert.IsFalse(isInvalidEmailResult);
        }

        /// <summary>
        /// Test IsStrongPassword method to ensure it correctly identifies strong and weak passwords.
        /// </summary>
        [TestMethod]
        public void IsStrongPassword_ShouldIdentifyStrongAndWeakPasswords()
        {
            // Arrange
            string validPassword   = "StrongP@ss1";
            string invalidPassword = "weak";

            // Act
            bool isValidPasswordResult   = validPassword.IsStrongPassword();
            bool isInvalidPasswordResult = invalidPassword.IsStrongPassword();

            // Assert
            Assert.IsTrue(isValidPasswordResult);
            Assert.IsFalse(isInvalidPasswordResult);
        }
    }
}
