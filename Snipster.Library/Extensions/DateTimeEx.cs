using System;
using System.Globalization;

namespace Snipster.Library.Extensions
{
    /// <summary>
    /// Provides various extensions for working with DateTime objects.
    /// </summary>
    public static class DateTimeEx
    {
        /// <summary>
        /// Converts a <see cref="DateTime"/> to a Unix timestamp (seconds since Unix epoch: 1970-01-01T00:00:00Z).
        /// </summary>
        /// <param name="date">The <see cref="DateTime"/> to convert. Treated as local or UTC depending on its <see cref="DateTime.Kind"/>.</param>
        /// <returns>
        /// A <see cref="long"/> representing the Unix timestamp.
        /// </returns>
        public static long ToUnixTimestamp(this DateTime date)
        {
            return new DateTimeOffset(date).ToUnixTimeSeconds();
        }

        /// <summary>
        /// Converts a Unix timestamp to DateTime (UTC). e.g. 1609459200 to 2021-01-01T00:00:00Z.
        /// </summary>
        /// <param name="timestamp">The Unix timestamp to convert.</param>
        /// <returns>
        /// The DateTime representing the Unix timestamp in UTC.
        /// </returns>
        public static DateTime FromUnixTimestamp(this long timestamp)
        {
            return DateTimeOffset.FromUnixTimeSeconds(timestamp).UtcDateTime;
        }

        /// <summary>
        /// Returns a human-readable "time ago" string (e.g. "3 hours ago").
        /// </summary>
        /// <param name="date">The date to convert to a "time ago" string.</param>
        /// <returns>
        /// A string representing how long ago the date was from now (e.g. "3 hours ago"). If the date is DateTime.MinValue or DateTime.MaxValue, returns "never". 
        /// If the date is in the future, returns "in the future"; otherwise, returns empty string.
        /// </returns>
        public static string ToTimeAgo(this DateTime date)
        {
            try
            {
                if (date == DateTime.MinValue || date == DateTime.MaxValue)
                    return "never";
                if (date > DateTime.UtcNow)
                    return "in the future";

                var ts = DateTime.UtcNow - date.ToUniversalTime();

                if (ts.TotalSeconds < 60)
                    return "just now";
                if (ts.TotalMinutes < 60)
                    return $"{(int)ts.TotalMinutes} minute{(ts.TotalMinutes >= 2 ? "s" : "")} ago";
                if (ts.TotalHours < 24)
                    return $"{(int)ts.TotalHours} hour{(ts.TotalHours >= 2 ? "s" : "")} ago";
                if (ts.TotalDays < 7)
                    return $"{(int)ts.TotalDays} day{(ts.TotalDays >= 2 ? "s" : "")} ago";
                if (ts.TotalDays < 30)
                    return $"{(int)(ts.TotalDays / 7)} week{(ts.TotalDays >= 14 ? "s" : "")} ago";
                if (ts.TotalDays < 365)
                    return $"{(int)(ts.TotalDays / 30)} month{(ts.TotalDays >= 60 ? "s" : "")} ago";

                return $"{(int)(ts.TotalDays / 365)} year{(ts.TotalDays >= 730 ? "s" : "")} ago";
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Converts DateTime to the start of the day (00:00:00).
        /// </summary>
        /// <param name="date">The date to convert.</param>
        /// <returns>
        /// A DateTime representing the start of the day (00:00:00) for the given date.
        /// </returns>
        public static DateTime StartOfDay(this DateTime date)
        {
            return date.Date;
        }

        /// <summary>
        /// Converts DateTime to the end of the day (23:59:59.999).
        /// </summary>
        /// <param name="date">The date to convert.</param>
        /// <returns>
        /// A DateTime representing the end of the day (23:59:59.999) for the given date.
        /// </returns>
        public static DateTime EndOfDay(this DateTime date)
        {
            return date.Date.AddDays(1).AddMilliseconds(-1);
        }

        /// <summary>
        /// Converts the specified <see cref="DateTime"/> to the specified time zone.
        /// </summary>
        /// <param name="date">The date to convert. Can be local or UTC.</param>
        /// <param name="timeZoneId">The IANA or Windows time zone ID (e.g. "Pacific Standard Time").</param>
        /// <returns>
        /// A <see cref="DateTime"/> representing the time in the specified time zone.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown when <paramref name="timeZoneId"/> is null, empty, not found, or invalid.
        /// </exception>
        public static DateTime ToTimeZone(this DateTime date, string timeZoneId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(timeZoneId))
                    throw new ArgumentException("Time zone Id must be provided.", nameof(timeZoneId));

                var tz = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
                return TimeZoneInfo.ConvertTimeFromUtc(date.ToUniversalTime(), tz);
            }
            catch (TimeZoneNotFoundException)
            {
                throw new ArgumentException($"Time zone '{timeZoneId}' was not found.", nameof(timeZoneId));
            }
            catch (InvalidTimeZoneException)
            {
                throw new ArgumentException($"Time zone '{timeZoneId}' is invalid or corrupted.", nameof(timeZoneId));
            }
        }

        /// <summary>
        /// Converts a date from a specific time zone to UTC.
        /// </summary>
        /// <param name="date">The local date in the specified time zone.</param>
        /// <param name="timeZoneId">The IANA or Windows time zone ID (e.g. "Pacific Standard Time").</param>
        /// <returns>
        /// A <see cref="DateTime"/> representing the UTC time equivalent of the given local date.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown when <paramref name="timeZoneId"/> is null, empty, not found, or invalid.
        /// </exception>
        public static DateTime FromTimeZone(this DateTime date, string timeZoneId)
        {
            if (string.IsNullOrWhiteSpace(timeZoneId))
                throw new ArgumentException("Time zone ID must be provided.", nameof(timeZoneId));

            try
            {
                var tz = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
                return TimeZoneInfo.ConvertTimeToUtc(date, tz);
            }
            catch (TimeZoneNotFoundException)
            {
                throw new ArgumentException($"Time zone '{timeZoneId}' was not found.", nameof(timeZoneId));
            }
            catch (InvalidTimeZoneException)
            {
                throw new ArgumentException($"Time zone '{timeZoneId}' is invalid or corrupted.", nameof(timeZoneId));
            }
        }

        /// <summary>
        /// Formats date as "yyyy-MM-dd".
        /// </summary>
        /// <param name="date">The date to format.</param>
        /// <returns>
        /// A string representing the date in "yyyy-MM-dd" format.
        /// </returns>
        public static string ToDateString(this DateTime date)
        {
            return date.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// Formats time as "HH:mm:ss".
        /// </summary>
        /// <param name="date">The date to format.</param>
        /// <returns>
        /// A string representing the time in "HH:mm:ss" format.
        /// </returns>
        public static string ToTimeString(this DateTime date)
        {
            return date.ToString("HH:mm:ss");
        }

        /// <summary>
        /// Formats as "yyyy-MM-dd HH:mm:ss".
        /// </summary>
        /// <param name="date">The date to format.</param>
        /// <returns>
        /// A string representing the date and time in "yyyy-MM-dd HH:mm:ss" format.
        /// </returns>
        public static string ToFullDateTimeString(this DateTime date)
        {
            return date.ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// Returns the start of the week (Monday) for the specified <see cref="DateTime"/>.
        /// </summary>
        /// <param name="date">The date to find the start of the week for.</param>
        /// <returns>
        /// A <see cref="DateTime"/> representing the Monday of that week.
        /// </returns>
        public static DateTime GetWeekStartDate(this DateTime date)
        {
            // calculate the difference in days from the start of the week (Monday)
            int diff = (7 + (date.DayOfWeek - DayOfWeek.Monday)) % 7;
            return date.Date.AddDays(-diff);
        }

        /// <summary>
        /// Returns the end of the week (Sunday) for the specified <see cref="DateTime"/>.
        /// </summary>
        /// <param name="date">The date to find the end of the week for.</param>
        /// <returns>
        /// A <see cref="DateTime"/> representing the Sunday of that week.
        /// </returns>
        public static DateTime GetWeekEndDate(this DateTime date)
        {
            // calculate the difference in days from the end of the week (Sunday)
            int diff = ((int)DayOfWeek.Sunday - (int)date.DayOfWeek + 7) % 7;
            return date.Date.AddDays(diff).AddDays(1).AddTicks(-1); // end of day
        }

        /// <summary>
        /// Gets the week number of the year (ISO 8601). e.g. 1 for the first week of the year.
        /// </summary>
        /// <param name="date">The date to get the week number for.</param>
        /// <returns>
        /// The week number of the year (1-53) for the given date.
        /// </returns>
        public static int GetWeekOfYear(this DateTime date)
        {
            var cal = CultureInfo.InvariantCulture.Calendar;
            return cal.GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

        /// <summary>
        /// Returns the age based on date of birth. e.g. if born on 1990-01-01 and today is 2023-10-01, returns 33.
        /// </summary>
        /// <param name="birthDate">The date of birth to calculate the age from.</param>
        /// <returns>
        /// The age in years based on the date of birth.
        /// </returns>
        public static int ToAge(this DateTime birthDate)
        {
            var today = DateTime.Today;
            var age   = today.Year - birthDate.Year;

            if (birthDate.Date > today.AddYears(-age)) 
                age--;

            return age;
        }
    }
}
