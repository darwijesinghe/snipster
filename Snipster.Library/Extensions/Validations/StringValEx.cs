using System;
using System.Text.RegularExpressions;

namespace Snipster.Library.Extensions.Validations
{
    /// <summary>
    /// Provides various extensions for validating strings.
    /// </summary>
    public static class StringValEx
    {
        /// <summary>
        /// Checks if the string contains another string with case-insensitive comparison.
        /// </summary>
        /// <param name="source">The source string to search within.</param>
        /// <param name="toCheck">The string to check for within the source string.</param>
        /// <returns>
        /// True if the source string contains the specified string, ignoring case; otherwise, false.
        /// </returns>
        public static bool IsContainsIgnoreCase(this string source, string toCheck)
        {
            return source?.IndexOf(toCheck, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        /// <summary>
        /// Validates whether the string is a valid Sri Lankan phone number (starting with 07, 10 digits).
        /// </summary>
        /// <param name="input">The input string to validate.</param>
        /// <returns>
        /// True if the string is a valid Sri Lankan phone number; otherwise, false.
        /// </returns>
        public static bool IsValidSriLankanPhone(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            return Regex.IsMatch(input, @"^(?:\+94|0)?7\d{8}$");
        }

        /// <summary>
        /// Checks if the string is a valid international phone number (starts with + and contains 10–15 digits).
        /// </summary>
        /// <param name="input">The input string to validate.</param>
        /// <returns>
        /// True if the string is a valid international phone number; otherwise, false.
        /// </returns>
        public static bool IsValidInternationalPhone(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            return Regex.IsMatch(input, @"^\+?\d{10,15}$");
        }

        /// <summary>
        /// Validates that a string contains only digits.
        /// </summary>
        /// <param name="input">The input string to validate.</param>
        /// <returns>
        /// True if the string contains only digits; otherwise, false.
        /// </returns>
        public static bool IsNumeric(this string input)
        {
            return !string.IsNullOrEmpty(input) && Regex.IsMatch(input, @"^\d+$");
        }

        /// <summary>
        /// Validates that a string contains only letters (no digits or symbols).
        /// </summary>
        /// <param name="input">The input string to validate.</param>
        /// <returns>
        /// True if the string contains only letters; otherwise, false.
        /// </returns>
        public static bool IsAlphabetic(this string input)
        {
            return !string.IsNullOrEmpty(input) && Regex.IsMatch(input, @"^[a-zA-Z]+$");
        }

        /// <summary>
        /// Validates that a string contains only letters or numbers.
        /// </summary>
        /// <param name="input">The input string to validate.</param>
        /// <returns>
        /// True if the string contains only letters or numbers; otherwise, false.
        /// </returns>
        public static bool IsAlphanumeric(this string input)
        {
            return !string.IsNullOrEmpty(input) && Regex.IsMatch(input, @"^[a-zA-Z0-9]+$");
        }
    }
}
