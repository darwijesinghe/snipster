using Snipster.Library.Helpers;

namespace Snipster.Test.Helpers
{
    /// <summary>
    /// Unit tests to validate the functionality of the StringFx class.
    /// </summary>
    [TestClass]
    public class StringFxTest
    {
        /// <summary>
        /// Tests the FormatBytes method to ensure it correctly formats byte sizes into human-readable strings.
        /// </summary>
        [TestMethod]
        public void FormatBytes_ShouldCorrectlyFormatByteSizeToHumanReadableString()
        {
            // Arrange
            long bytes              = 1500000;      // 1.5 MB
            string expected         = "1.43 MB";    // expected output with 2 decimal places
            string negativeExpected = "-1.43 MB";   // expected output for negative input

            // Act
            string formattedBytes         = StringFx.FormatBytes(bytes, 2);
            string negativeFormattedBytes = StringFx.FormatBytes(-bytes, 2);

            // Assert
            Assert.AreEqual(expected, formattedBytes);
            Assert.AreEqual(negativeExpected, negativeFormattedBytes);
        }

        /// <summary>
        /// Tests the GenerateUniqueUsername method to ensure it generates a unique username based on first and last names.
        /// </summary>
        [TestMethod]
        public void GenerateUniqueUsername_ShouldGenerateUniqueUserName()
        {
            // Arrange
            string firstName = "John";
            string lastName = "Doe";

            // Simulate a username check function
            Func<string, bool> isUsernameTaken = username =>
            {
                // Simulate that "johndoe" and "johndoe1" are taken
                return username == "johndoe" || username == "johndoe1";
            };

            // The next available username
            string expected = "johndoe2";

            // Act
            string uniqueUsername = StringFx.GenerateUniqueUsername(firstName, lastName, isUsernameTaken);

            // Assert
            Assert.AreEqual(expected, uniqueUsername);
        }

        /// <summary>
        /// Tests the GenerateGuid method to ensure it generates a new GUID without dashes.
        /// </summary>
        [TestMethod]
        public void GenerateGuid_ShouldGenerateNewGuidWithoutDashes()
        {
            // Arrange
            bool includeDashes = false;

            // Act
            string guid = StringFx.GenerateGuid(includeDashes);

            // Assert
            Assert.IsNotNull(guid);
            Assert.AreEqual(32, guid.Length);
            Assert.IsFalse(guid.Contains("-"));
        }

        /// <summary>
        /// Tests the GenerateGuid method to ensure it generates a new GUID with dashes.
        /// </summary>
        [TestMethod]
        public void GenerateGuid_ShouldGenerateNewGuidWithDashes()
        {
            // Arrange
            bool includeDashes = true;

            // Act
            string guid = StringFx.GenerateGuid(includeDashes);

            // Assert
            Assert.IsNotNull(guid);

            // The GUID format is "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx"
            Assert.AreEqual(36, guid.Length); 

            Assert.IsTrue(guid.Contains("-"));
        }
    }
}
