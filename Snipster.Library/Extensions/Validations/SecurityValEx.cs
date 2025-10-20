using System.Text.RegularExpressions;

namespace Snipster.Library.Extensions.Validations
{
    /// <summary>
    /// Provides various extensions for validating security-related values.
    /// </summary>
    public static class SecurityValEx
    {
        /// <summary>
        /// Validates string type email address.
        /// </summary>
        /// <param name="email">The input email address that needs to be validated.</param>
        /// <returns>
        /// True if the email address is valid; otherwise false.
        /// </returns>
        public static bool IsValidEmail(this string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // attempt to create a MailAddress object to validate the email format
                var addr = new System.Net.Mail.MailAddress(email);

                // check if the address matches the original email string
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Validates if a password meets basic rules (length, upper, lower, number, special).
        /// </summary>
        /// <param name="input">The input string to validate.</param>
        /// <param name="minLength">The minimum length for the password.</param>
        /// <returns>
        /// True if the password is strong; otherwise, false.
        /// </returns>
        public static bool IsStrongPassword(this string input, int minLength = 8)
        {
            if (string.IsNullOrEmpty(input) || input.Length < minLength)
                return false;

            return Regex.IsMatch(input, @"[A-Z]") &&     // at least one uppercase
                   Regex.IsMatch(input, @"[a-z]") &&     // at least one lowercase
                   Regex.IsMatch(input, @"[0-9]") &&     // at least one digit
                   Regex.IsMatch(input, @"[\W_]");       // at least one special char
        }
    }
}
