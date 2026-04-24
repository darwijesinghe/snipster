using Snipster.Library.Enums;
using System.Linq;

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
        /// A type of <see cref="CardType"/> representing the identified credit card type. If the card type cannot be determined, it returns <see cref="CardType.Unknown"/>.
        /// </returns>
        public static CardType GetCreditCardType(this string number)
        {
            if (string.IsNullOrWhiteSpace(number))
                return CardType.Unknown;

            number = number.Replace(" ", "");

            if (!number.All(char.IsDigit))
                return CardType.Unknown;

            int length = number.Length;

            // helper function used to check whether a number starts with a prefix that falls within a numeric range
            bool StartsWithRange(string input, int start, int end, int digits)
            {
                if (input.Length < digits) 
                    return false;

                int prefix = int.Parse(input.Substring(0, digits));
                return prefix >= start && prefix <= end;
            }

            if (number.StartsWith("4") && (length == 13 || length == 16 || length == 19))
                return CardType.Visa;

            if ((StartsWithRange(number, 51, 55, 2) || StartsWithRange(number, 2221, 2720, 4)) && length == 16)
                return CardType.MasterCard;

            if ((number.StartsWith("34") || number.StartsWith("37")) && length == 15)
                return CardType.AmericanExpress;

            if ((number.StartsWith("6011") || number.StartsWith("65") || StartsWithRange(number, 644, 649, 3)) && length == 16)
                return CardType.Discover;

            if (StartsWithRange(number, 3528, 3589, 4) && length == 16)
                return CardType.JCB;

            if ((StartsWithRange(number, 300, 305, 3) || number.StartsWith("36") || number.StartsWith("38")) && length == 14)
                return CardType.DinersClub;

            return CardType.Unknown;
        }
    }
}
