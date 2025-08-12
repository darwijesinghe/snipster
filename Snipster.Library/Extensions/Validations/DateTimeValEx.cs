using System;
using System.Globalization;

namespace Snipster.Library.Extensions.Validations
{
    /// <summary>
    /// Provides various extensions for validating DateTime values.
    /// </summary>
    public static class DateTimeValEx
    {
        /// <summary>
        /// Returns true if the date is today.
        /// </summary>
        /// <param name="date">The date to check.</param>
        /// <returns>
        /// True if the date is today; otherwise, false.
        /// </returns>
        public static bool IsToday(this DateTime date)
        {
            return date.Date == DateTime.Today;
        }

        /// <summary>
        /// Returns true if the date is in the future.
        /// </summary>
        /// <param name="date">The date to check.</param>
        /// <returns>
        /// True if the date is in the future; otherwise, false.
        /// </returns>
        public static bool IsFuture(this DateTime date)
        {
            return date > DateTime.Now;
        }

        /// <summary>
        /// Returns true if the date is in the past.
        /// </summary>
        /// <param name="date">The date to check.</param>
        /// <returns>
        /// True if the date is in the past; otherwise, false.
        /// </returns>
        public static bool IsPast(this DateTime date)
        {
            return date < DateTime.Now;
        }

        /// <summary>
        /// Returns true if the date is a weekend (Saturday or Sunday).
        /// </summary>
        /// <param name="date">The date to check.</param>
        /// <returns>
        /// True if the date is a weekend; otherwise, false.
        /// </returns>
        public static bool IsWeekend(this DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
        }

        /// <summary>
        /// Returns true if the date is a weekday (Monday–Friday).
        /// </summary>
        /// <param name="date">The date to check.</param>
        /// <returns>
        /// True if the date is a weekday; otherwise, false.
        /// </returns>
        public static bool IsWeekday(this DateTime date)
        {
            return !IsWeekend(date);
        }

        /// <summary>
        /// Validates if a given string is a valid date in a specific format.
        /// </summary>
        /// <param name="input"> The input string to validate.</param>
        /// <param name="format"> The date format to validate against (default is "yyyy-MM-dd").</param>
        /// <returns>
        /// True if the string is a valid date in the specified format; otherwise, false.
        /// </returns>
        public static bool IsValidDate(this string input, string format = "yyyy-MM-dd")
        {
            return DateTime.TryParseExact(
                input,
                format,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out _);
        }
    }
}
