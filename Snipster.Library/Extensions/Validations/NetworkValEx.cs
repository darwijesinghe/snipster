using System.Text.RegularExpressions;

namespace Snipster.Library.Extensions.Validations
{
    /// <summary>
    /// Provides various extensions for validating network-related values.
    /// </summary>
    public static class NetworkValEx
    {
        /// <summary>
        /// Validates if a given string is a valid IPv4 address.
        /// </summary>
        /// <param name="input"> The input string to validate.</param>
        /// <returns>
        /// True if the string is a valid IPv4 address; otherwise, false.
        /// </returns>
        public static bool IsValidIPv4(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            return Regex.IsMatch(input, @"^(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d\d|[1-9]?\d)){3}$");
        }
    }
}
