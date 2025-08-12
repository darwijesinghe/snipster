using System;

namespace Snipster.Library.Helpers
{
    /// <summary>
    /// Provides various string manipulation and validation methods.
    /// </summary>
    public static class StringFx
    {
        /// <summary>
        /// Formats a byte size into a human-readable string (e.g. "1.5 MB", "200 KB").
        /// </summary>
        /// <param name="bytes">The size in bytes to format.</param>
        /// <param name="decimals">The number of decimal places to include in the formatted string (default is 2).</param>
        /// <returns>
        /// A formatted string representing the byte size in a human-readable format, such as "1.5 MB" or "200 KB". If the input is 
        /// negative, it will prepend a minus sign to the result.
        /// </returns>
        public static string FormatBytes(long bytes, int decimals = 2)
        {
            if (bytes < 0)
                return "-" + FormatBytes(-bytes, decimals);

            // sizes symbols
            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            int order      = 0;
            double len     = bytes;

            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len /= 1024;
            }

            return $"{Math.Round(len, decimals)} {sizes[order]}";
        }

        /// <summary>
        /// Generates a unique username using the first and last name. Appends a number if the base username is already taken.
        /// </summary>
        /// <param name="firstName">The user's first name.</param>
        /// <param name="lastName">The user's last name.</param>
        /// <param name="isUsernameTaken">A delegate to check if a username is already taken.</param>
        /// <returns>
        /// A unique username generated from the first and last name, ensuring it is not already taken.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown when first name or last name is null or empty.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the username check function is null.
        /// </exception>
        public static string GenerateUniqueUsername(string firstName, string lastName, Func<string, bool> isUsernameTaken)
        {
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("First name and last name are required.");

            if (isUsernameTaken == null)
                throw new ArgumentNullException(nameof(isUsernameTaken), "Username check function cannot be null.");

            string baseUsername = (firstName + lastName).ToLowerInvariant().Replace(" ", "");
            string username     = baseUsername;
            int counter         = 1;

            while (isUsernameTaken(username))
            {
                username = $"{baseUsername}{counter}";
                counter++;
            }

            return username;
        }

        /// <summary>
        /// Generates a new GUID as a string.
        /// </summary>
        /// <param name="includeDashes">If true, the GUID will include dashes; otherwise, it will be a continuous string without dashes.</param>
        /// <returns>
        /// A string representation of a new GUID. If includeDashes is true, the format will be "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx";
        /// </returns>
        public static string GenerateGuid(bool includeDashes)
        {
            return includeDashes ? Guid.NewGuid().ToString() : Guid.NewGuid().ToString("N");
        }
    }
}
