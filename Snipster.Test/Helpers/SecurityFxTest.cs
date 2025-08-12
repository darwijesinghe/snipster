using Snipster.Library.Helpers;

namespace Snipster.Test.Helpers
{
    /// <summary>
    /// Unit tests to validate the functionality of the SecurityFx class.
    /// </summary>
    [TestClass]
    public class SecurityFxTest
    {
        /// <summary>
        /// Tests the RandomString method to ensure it generates a random string of the specified length using allowed characters.
        /// </summary>
        [TestMethod]
        public void RandomString_ShouldGenerateRandomString()
        {
            // Arrange
            int length          = 16;
            string allowedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            // Act
            string randomString = SecurityFx.RandomString(length, allowedChars);

            // Assert
            Assert.IsNotNull(randomString);
            Assert.AreEqual(length, randomString.Length);
        }

        /// <summary>
        /// Tests the GenerateSecureToken method to ensure it generates a secure random token of the specified length.
        /// </summary>
        [TestMethod]
        public void GenerateSecureToken_ShouldGenerateSecureToken()
        {
            // Arrange
            int length = 32;

            // Act
            string secureToken = SecurityFx.GenerateSecureToken(length);

            // Assert
            Assert.IsNotNull(secureToken);
            Assert.AreEqual(length, secureToken.Length);
        }

        /// <summary>
        /// Tests the PasswordHash method to ensure it generates a hashed password and salt correctly.
        /// </summary>
        [TestMethod]
        public void PasswordHash_ShouldGenerateHashedPasswordAndSalt()
        {
            // Arrange
            string password = "TestPassword";
            byte[] passwordHash;
            byte[] passwordSalt;

            // Act
            SecurityFx.PasswordHash(password, out passwordHash, out passwordSalt);

            // Assert
            Assert.IsNotNull(passwordHash);
            Assert.IsNotNull(passwordSalt);
            Assert.IsTrue(passwordHash.Length > 0);
            Assert.IsTrue(passwordSalt.Length > 0);
        }

        /// <summary>
        /// Tests the VerifyPassword method to ensure it correctly verifies a password against a stored hash and salt.
        /// </summary>
        [TestMethod]
        public void VerifyPassword_ShouldVerifyStoredPasswordCorrectly()
        {
            // Arrange
            string password = "TestPassword";
            SecurityFx.PasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            // Act
            bool isVerified = SecurityFx.VerifyPassword(password, passwordHash, passwordSalt);

            // Assert
            Assert.IsTrue(isVerified);
        }
    }
}
