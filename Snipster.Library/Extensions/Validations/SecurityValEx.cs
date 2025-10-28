using System.Net.Mail;
using System.Text.RegularExpressions;

namespace Snipster.Library.Extensions.Validations
{
    /// <summary>
    /// Provides various extensions for validating security-related values.
    /// </summary>
    public static class SecurityValEx
    {
        /// <summary>
        /// Validates whether the given string is a properly formatted email address.
        /// Supports both ASCII and Unicode (internationalized) formats based on the <paramref name="allowUnicode"/> flag.
        /// Uses <see cref="MailAddress"/> for RFC-compliant parsing.
        /// </summary>
        /// <param name="email">The email address string to validate.</param>
        /// <param name="allowUnicode">
        /// If true, allows Unicode letters and digits (for IDN and internationalized emails). If false, restricts to ASCII only.
        /// </param>
        /// <returns>
        /// True if the email address is valid; otherwise, false.
        /// </returns>
        public static bool IsValidEmail(this string email, bool allowUnicode = false)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            // pattern: must start & end with letter/number; no consecutive dots; valid domain
            string pattern = allowUnicode
                ? @"^(?!\.)(?!.*\.\.)([\p{L}\p{M}\p{N}](?:[\p{L}\p{M}\p{N}!#$%&'*+/=?^_`{|}~.-]*[\p{L}\p{M}\p{N}])?)@(?:[\p{L}\p{M}\p{N}](?:[\p{L}\p{M}\p{N}-]*[\p{L}\p{M}\p{N}])?\.)+[\p{L}\p{M}]{2,}$"
                : @"^(?!\.)(?!.*\.\.)([A-Za-z0-9](?:[A-Za-z0-9!#$%&'*+/=?^_`{|}~.-]*[A-Za-z0-9])?)@(?:[A-Za-z0-9](?:[A-Za-z0-9-]*[A-Za-z0-9])?\.)+[A-Za-z]{2,}$";

            if (!Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.CultureInvariant))
                return false;

            try
            {
                // attempt to create a MailAddress object to validate the email format
                var addr = new MailAddress(email);

                // check if the address matches the original email string
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Determines whether the specified password is considered strong based on length,
        /// character variety, and Unicode support.
        /// </summary>
        /// <param name="input">The input string to validate.</param>
        /// <param name="minLength">The minimum number of characters required for a valid password. Defaults to <c>8</c>.</param>
        /// <returns>
        /// True if the password is strong; otherwise, false.
        /// </returns>
        /// <remarks>
        /// A strong password must be at least the specified minimum length and include:<br/>
        /// <list type="bullet">
        /// <item>Letters (uppercase and lowercase, or any Unicode letters).</item>
        /// <item>At least one digit.</item>
        /// <item>At least one symbol or punctuation character.</item>
        /// </list>
        /// </remarks>
        public static bool IsStrongPassword(this string input, int minLength = 8)
        {
            if (string.IsNullOrEmpty(input) || input.Length < minLength)
                return false;

            // digits (Unicode aware)
            bool hasDigit     = Regex.IsMatch(input, @"\p{Nd}");

            // symbol/punctuation/other symbol (includes emoji, currency, punctuation)
            bool hasSymbol    = Regex.IsMatch(input, @"[\p{P}\p{S}_]");

            // cased letters: uppercase and lowercase (for scripts that have case)
            bool hasUpper     = Regex.IsMatch(input, @"\p{Lu}");
            bool hasLower     = Regex.IsMatch(input, @"\p{Ll}");

            // any letter (covers scripts without case, e.g. Japanese, Chinese)
            bool hasAnyLetter = Regex.IsMatch(input, @"\p{L}");

            // if there are cased letters in the string, require both Upper & Lower
            bool letterRequirementSatisfied = (hasUpper || hasLower)
                ? (hasUpper && hasLower)   // script has case -> require both
                : hasAnyLetter;            // script has no case -> require at least one letter

            return hasDigit && hasSymbol && letterRequirementSatisfied;
        }
    }
}
