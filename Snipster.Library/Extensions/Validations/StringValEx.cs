using PhoneNumbers;
using System;
using System.Linq;

namespace Snipster.Library.Extensions.Validations
{
    /// <summary>
    /// Provides various extensions for validating strings.
    /// </summary>
    public static class StringValEx
    {
        // PhoneNumberUtil is thread-safe and expensive to create.
        // Reusing a single instance is recommended by libphonenumber.
        private static readonly PhoneNumberUtil _phoneUtil;

        static StringValEx()
        {
            _phoneUtil = PhoneNumberUtil.GetInstance();
        }

        /// <summary>
        /// Checks if the string contains another string with case-insensitive comparison.
        /// </summary>
        /// <param name="source">The source string to search within.</param>
        /// <param name="toCheck">The string to check for within the source string.</param>
        /// <returns>
        /// <see langword="true"/> if the source string contains the specified string, ignoring case; otherwise, <see langword="false"/>.
        /// </returns>
        public static bool IsContainsIgnoreCase(this string source, string toCheck)
        {
            if (source is null || toCheck is null)
                return false;

            return source?.IndexOf(toCheck, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        /// <summary>
        /// Validates a phone number and returns it in E.164 format. Accepts common user input and applies 
        /// region-specific rules when needed.
        /// </summary>
        /// <param name="input">Raw phone number provided by the user. (e.g. "+94 70 229 3007", "0702293007").</param>
        /// <param name="region">ISO country code required for numbers without a leading + prefix.</param>
        /// <param name="formattedNumber">When valid, contains the normalized E.164 phone number; otherwise, null.</param>
        /// <returns>
        /// <see langword="true"/> if the phone number is valid; otherwise, <see langword="false"/>.
        /// </returns>
        public static bool IsValidPhoneNumber(this string input, string? region, out string? formattedNumber)
        {
            formattedNumber = null;

            if (string.IsNullOrWhiteSpace(input))
                return false;

            try
            {
                // parses common formatting characters (handles spaces, (), -, etc.)
                var phoneNumber = _phoneUtil.Parse(input, region);

                // validate according to libphonenumber's rules
                if (!_phoneUtil.IsValidNumber(phoneNumber))
                    return false;

                // format the number into a consistent, globally recognized format
                formattedNumber = _phoneUtil.Format(phoneNumber, PhoneNumberFormat.E164);
                return true;
            }
            catch (NumberParseException)
            {
                // parsing failed due to invalid format or unknown region
                return false;
            }
        }

        /// <summary>
        /// Determines whether the string contains only ASCII numeric digits (0–9). Does not allow 
        /// whitespace, signs (+, -), decimals, or Unicode digits.
        /// </summary>
        /// <param name="input">The string to validate.</param>
        /// <returns>
        /// <see langword="true"/> if the string contains only ASCII digits; otherwise, <see langword="false"/>.
        /// </returns>
        public static bool IsNumeric(this string input)
        {
            return !string.IsNullOrWhiteSpace(input) && input.All(c => c >= '0' && c <= '9');
        }

        /// <summary>
        /// Determines whether the string contains only English alphabetic characters (A–Z, a–z). Does not allow 
        /// spaces, accents (é, ü), or Unicode letters.
        /// </summary>
        /// <param name="input">The string to validate.</param>
        /// <returns>
        /// <see langword="true"/> if the string contains only English letters (A–Z, a–z); otherwise, <see langword="false"/>.
        /// </returns>
        public static bool IsAlphabetic(this string input)
        {
            return !string.IsNullOrWhiteSpace(input) 
                && input.All(c => (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z'));
        }

        /// <summary>
        /// Determines whether the string contains only English letters and ASCII digits (A–Z, a–z, 0-9). Does not allow 
        /// underscores, hyphens, spaces, symbols, or Unicode characters.
        /// </summary>
        /// <param name="input">The string to validate.</param>
        /// <returns>
        /// <see langword="true"/> if the string contains only English letters (A–Z, a–z)
        /// and digits (0–9); otherwise, <see langword="false"/><see langword="false"/>.
        /// </returns>
        public static bool IsAlphanumeric(this string input)
        {
            return !string.IsNullOrWhiteSpace(input)
                && input.All(c => (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || (c >= '0' && c <= '9'));
        }
    }
}