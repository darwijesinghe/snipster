using System.Text.RegularExpressions;

namespace Snipster.Library.Extensions
{
    /// <summary>
    /// Provides various extensions for working with credit card information.
    /// </summary>
    public static class CreditCardEx
    {
        /// <summary>
        /// Determines the type of credit card based on its number. Supports various card types 
        /// such as Visa, MasterCard, American Express, Discover, JCB, and Diners Club.
        /// </summary>
        /// <param name="number">The credit card number as a string.</param>
        /// <returns>
        /// A string representing the type of credit card (e.g., "Visa", "MasterCard", etc.).
        /// "Unknown" if the type cannot be determined or if the input is invalid, empty or non-numeric input.
        /// </returns>
        public static string GetCreditCardType(this string number)
        {
            if (string.IsNullOrWhiteSpace(number))
                return "Unknown";

            // strip spaces
            number = Regex.Replace(number, @"\s+", "");

            // check if the number is numeric
            if (!Regex.IsMatch(number, @"^\d+$"))
                return "Unknown";

            if (Regex.IsMatch(number, @"^4\d{12}(\d{3})?(\d{3})?$"))
                return "Visa";

            if (Regex.IsMatch(number, @"^(5[1-5]\d{14}|2(2[2-9][1-9]|2[3-9]\d|[3-6]\d{2}|7[01]\d|720)\d{12})$"))
                return "MasterCard";

            if (Regex.IsMatch(number, @"^3[47]\d{13}$"))
                return "American Express";

            if (Regex.IsMatch(number, @"^6(?:011|5\d{2}|4[4-9]\d)\d{12}$"))
                return "Discover";

            if (Regex.IsMatch(number, @"^35(2[89]|[3-8][0-9])\d{12}$"))
                return "JCB";

            if (Regex.IsMatch(number, @"^3(?:0[0-5]|[68]\d)\d{11}$"))
                return "Diners Club";

            return "Unknown";
        }
    }
}
