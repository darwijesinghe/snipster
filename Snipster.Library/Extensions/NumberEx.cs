namespace Snipster.Library.Extensions
{
    /// <summary>
    /// Provides various extensions for working with numbers.
    /// </summary>
    public static class NumberEx
    {
        /// <summary>
        /// Converts a number to its ordinal representation as a string. e.g. "1st", "2nd", "3rd", "4th", etc.
        /// </summary>
        /// <param name="number">The number to convert.</param>
        /// <returns>
        /// A string representing the ordinal form of the number.
        /// </returns>
        public static string ToOrdinal(this int number)
        {
            if (number <= 0)
                return number.ToString();

            // handle special cases for 11, 12, and 13
            int reminder = number % 100;
            if (reminder >= 11 && reminder <= 13)
                return $"{number}th";

            return (number % 10) switch
            {
                1 => $"{number}st",
                2 => $"{number}nd",
                3 => $"{number}rd",
                _ => $"{number}th",
            };
        }

        /// <summary>
        /// Converts string to an integer safely, returns default if invalid. e.g. "123" becomes 123, "abc" becomes 0.
        /// </summary>
        /// <param name="input">The input string to convert.</param>
        /// <param name="defaultValue"> The default value to return if the conversion fails (default is 0).</param>
        /// <returns>
        /// An integer representation of the string if valid; otherwise, the specified default value (default is 0).
        /// </returns>
        public static int ToIntSafe(this string input, int defaultValue = 0)
        {
            return int.TryParse(input, out int result) ? result : defaultValue;
        }

        /// <summary>
        /// Converts string to a double safely, returns default if invalid. e.g. "123.45" becomes 123.45, "abc" becomes 0.
        /// </summary>
        /// <param name="input">The input string to convert.</param>
        /// <param name="defaultValue"> The default value to return if the conversion fails (default is 0).</param>
        /// <returns>
        /// A double representation of the string if valid; otherwise, the specified default value (default is 0).
        /// </returns>
        public static double ToDoubleSafe(this string input, double defaultValue = 0)
        {
            return double.TryParse(input, out double result) ? result : defaultValue;
        }
    }
}
