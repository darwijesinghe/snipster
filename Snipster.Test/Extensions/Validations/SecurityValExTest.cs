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
        [DataTestMethod]

        // Valid cases
        [DataRow("user@example.com", true)]
        [DataRow("user.name@example.com", true)]
        [DataRow("user_name@example.co.uk", true)]
        [DataRow("user-name+tag@example.org", true)]
        [DataRow("user@sub.example.com", true)]

        // Invalid cases
        [DataRow("", false)]
        [DataRow("   ", false)]
        [DataRow("plainaddress", false)]
        [DataRow("@example.com", false)]
        [DataRow("user@", false)]
        [DataRow("user@.com", false)]
        [DataRow(".username@example.com", false)]
        [DataRow("username.@example.com", false)]
        [DataRow("user..name@example.com", false)]
        [DataRow("user@example", false)]
        [DataRow("user@example..com", false)]
        [DataRow("user@-example.com", false)]
        [DataRow("user@example-.com", false)]
        [DataRow("!!!@example.com", false)]

        // Unicode cases (when not allowed)
        [DataRow("usér@example.com", false)]
        public void IsValidEmail_ShouldValidateCorrectly(string email, bool expected)
        {
            // Act
            bool result = email.IsValidEmail();

            // Assert
            Assert.AreEqual(expected, result, $"Failed for: {email}");
        }

        /// <summary>
        /// Test IsValidEmail method with Unicode support to ensure it correctly identifies valid and invalid email formats.
        /// </summary>
        [DataTestMethod]

        // Valid cases
        [DataRow("user@example.com", true)]
        [DataRow("user.name@example.com", true)]
        [DataRow("user-name+tag@example.org", true)]

        // Invalid cases
        [DataRow("!!!@example.com", false)]
        [DataRow("user..name@example.com", false)]
        [DataRow(".username@example.com", false)]
        [DataRow("username.@example.com", false)]
        [DataRow("user@-example.com", false)]
        [DataRow("user@example-.com", false)]
        [DataRow("user@example..com", false)]

        // Valid unicode cases (when allowed)
        [DataRow("usér@dömäin.com", true)]
        [DataRow("usér@mail.例子.公司", true)]
        [DataRow("δοκιμή@παράδειγμα.ελ", true)]    // Greek example
        [DataRow("почта@пример.рф", true)]         // Cyrillic example
        [DataRow("用户@例子.公司", true)]            // Chinese example
        [DataRow("उपयोगकर्ता@उदाहरण.भारत", true)]     // Hindi example
        
        // Invalid unicode cases
        [DataRow("usér..name@dömäin.com", false)]
        [DataRow("usér@.dömäin.com", false)]
        [DataRow(".usér@dömäin.com", false)]
        [DataRow("usér@dömäin..com", false)]
        public void IsValidEmail_ShouldValidateUnicodeEmails(string email, bool expected)
        {
            // Act
            bool result = email.IsValidEmail(allowUnicode: true);

            // Assert
            Assert.AreEqual(expected, result, $"Failed for: {email}");
        }

        /// <summary>
        /// Test IsStrongPassword method to ensure it correctly identifies strong and weak passwords.
        /// </summary>
        [DataTestMethod]

        // Valid cases
        [DataRow("StrongP@ss1", true)]
        [DataRow("A1b2C3d4!", true)]
        [DataRow("Good#Password9", true)]
        [DataRow("My_SecureP@ssw0rd", true)]

        // Invalid cases
        [DataRow("weak", false)]
        [DataRow("password", false)]
        [DataRow("PASSWORD", false)]
        [DataRow("Password", false)]
        [DataRow("Password1", false)]
        [DataRow("Pass@word", false )]
        [DataRow("12345678", false)]
        [DataRow("!!!!!!!!", false)]
        [DataRow("Short1!", false)]

        // Edge and Unicode cases
        [DataRow("Ünicode1@", true)]
        [DataRow("パスワード123@", true)]
        [DataRow("密码1@", false)]

        public void IsStrongPassword_ShouldIdentifyStrongAndWeakPasswords(string password, bool expected)
        {
            // Act
            bool result = password.IsStrongPassword();

            // Assert
            Assert.AreEqual(expected, result, $"Password '{password}' validation failed.");
        }
    }
}
