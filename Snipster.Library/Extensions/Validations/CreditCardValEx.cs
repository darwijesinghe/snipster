using System.Text.RegularExpressions;

namespace Snipster.Library.Extensions.Validations
{
    /// <summary>
    /// Provides various extensions for validating credit card information.
    /// </summary>
    public static class CreditCardValEx
    {
        /// <summary>
        /// Validates if a given string is a valid credit card number using Luhn algorithm.
        /// </summary>
        /// <param name="input"> The credit card number as a string.</param>
        /// <returns>
        /// True if the string is a valid credit card number; otherwise, false.
        /// </returns>
        public static bool IsValidCreditCard(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            // remove all non-digit characters (spaces, dashes, etc.)
            input = Regex.Replace(input, @"\s+", "");

            int sum = 0;
            bool alternate = false;

            // Luhn algorithm: process digits from right to left
            for (int i = input.Length - 1; i >= 0; i--)
            {
                // check if character is a digit
                if (!char.IsDigit(input[i])) return false;

                // convert character to integer
                int n = input[i] - '0';

                // double every second digit
                if (alternate)
                {
                    n *= 2;
                    if (n > 9) n -= 9;
                }

                // add to sum
                sum += n;

                // toggle alternate flag
                alternate = !alternate;
            }

            // check if sum is divisible by 10
            return sum % 10 == 0;
        }
    }
}
