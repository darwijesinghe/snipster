using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace Snipster.Library.Extensions
{
    /// <summary>
    /// Provides various string manipulation and formatting extension methods.
    /// </summary>
    public static class StringEx
    {
        /// <summary>
        /// Capitalizes the first character of the string, leaving the rest unchanged.
        /// </summary>
        /// <param name="input">The input string to modify.</param>
        /// <returns>
        /// A string with the first character converted to uppercase; otherwise, returns the original string if it is null or empty.
        /// </returns>
        public static string CapitalizeFirst(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            return char.ToUpper(input[0]) + input.Substring(1);
        }

        /// <summary>
        /// Converts string to Title Case. e.g. "hello world" becomes "Hello World".
        /// </summary>
        /// <param name="input">The input string to convert.</param>
        /// <returns>
        /// A string converted to Title Case, where the first letter of each word is capitalized; otherwise, returns the 
        /// original string if it is null or empty.
        /// </returns>
        public static string ToTitleCase(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
        }

        /// <summary>
        /// Removes all non-numeric characters.
        /// </summary>
        /// <param name="input">The input string to filter.</param>
        /// <returns>
        /// A string containing only the numeric characters from the input; otherwise, returns the original string  if it is null or empty.
        /// </returns>
        public static string OnlyDigits(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            return new string(input.Where(char.IsDigit).ToArray());
        }

        /// <summary>
        /// Truncates the string to a specified maximum length and optionally appends a suffix (e.g. "...").
        /// </summary>
        /// <param name="input">The original string to truncate.</param>
        /// <param name="maxLength">The maximum number of characters to retain from the input string.</param>
        /// <param name="suffix">
        /// The optional suffix to append if the string is truncated. Defaults to "...".
        /// If null is provided, no suffix will be appended.
        /// </param>
        /// <returns>
        /// A truncated version of the input string if it exceeds the specified maximum length; otherwise, returns the original 
        /// string if it is null, empty, or does not exceed the maximum length.
        /// </returns>
        public static string Truncate(this string input, int maxLength, string suffix = "...")
        {
            if (string.IsNullOrEmpty(input) || input.Length <= maxLength)
                return input;

            return input.Substring(0, maxLength) + (suffix ?? "");
        }

        /// <summary>
        /// Slugifies a string (e.g. "Hello World!" => "hello-world").
        /// </summary>
        /// <param name="input">The input string to slugify.</param>
        /// <returns>
        /// A slugified version of the input string, suitable for use in URLs; otherwise, returns the original string if it is null or empty.
        /// </returns>
        public static string Slugify(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            string normalized = input.ToLowerInvariant().Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();

            foreach (char c in normalized)
            {
                if (char.IsLetterOrDigit(c)) sb.Append(c);
                else if (char.IsWhiteSpace(c) || c == '-' || c == '_') sb.Append('-');
            }

            return Regex.Replace(sb.ToString(), @"[-]+", "-").Trim('-');
        }

        /// <summary>
        /// Converts a string to Base64.
        /// </summary>
        /// <param name="input">The input string to encode.</param>
        /// <returns>
        /// A Base64-encoded string representation of the input; otherwise, returns the original string if it is null or empty.
        /// </returns>
        public static string ToBase64(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            return Convert.ToBase64String(Encoding.UTF8.GetBytes(input));
        }

        /// <summary>
        /// Decodes a Base64-encoded string.
        /// </summary>
        /// <param name="base64">The Base64-encoded string to decode.</param>
        /// <returns>
        /// A decoded string from the Base64 input; otherwise, returns the original string if it is null or empty.
        /// </returns>
        public static string FromBase64(this string base64)
        {
            if (string.IsNullOrEmpty(base64))
                return base64;

            return Encoding.UTF8.GetString(Convert.FromBase64String(base64));
        }

        /// <summary>
        /// Returns a default value if string is null or empty.
        /// </summary>
        /// <param name="input">The input string to check.</param>
        /// <param name="defaultValue">The default value to return if the input is null or empty.</param>
        /// <returns>
        /// The original string if it is not null or empty; otherwise, the specified default value.
        /// </returns>
        public static string? OrDefault(this string? input, string defaultValue)
        {
            return string.IsNullOrEmpty(input) ? defaultValue : input;
        }

        /// <summary>
        /// Removes HTML tags from the string.
        /// </summary>
        /// <param name="input">The input string containing HTML tags.</param>
        /// <returns>
        /// A string with all HTML tags removed; otherwise, returns the original string if it is null or empty.
        /// </returns>
        public static string StripHtmlTags(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            return Regex.Replace(input, "<.*?>", string.Empty);
        }

        /// <summary>
        /// Removes all non-alphanumeric characters from a string.
        /// </summary>
        /// <param name="input">The input string to sanitize.</param>
        /// <returns>
        /// A string containing only alphanumeric characters from the input; otherwise, returns the original string if it is 
        /// null or empty.
        /// </returns>
        public static string SanitizeAlphanumeric(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            return Regex.Replace(input, "[^a-zA-Z0-9]", "");
        }

        /// <summary>
        /// Removes all special characters except spaces.
        /// </summary>
        /// <param name="input">The input string to sanitize.</param>
        /// <returns>
        /// A string containing only alphanumeric characters and spaces from the input; otherwise, returns the 
        /// original string if it is null or empty.
        /// </returns>
        public static string RemoveSpecialCharacters(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            return Regex.Replace(input, @"[^0-9a-zA-Z\s]", "");
        }

        /// <summary>
        /// Converts a string to CamelCase format. e.g. "hello world" becomes "helloWorld".
        /// </summary>
        /// <param name="input">The input string to convert.</param>
        /// <returns>
        /// A CamelCase version of the input string, where the first letter is lowercase and subsequent words are capitalized; 
        /// otherwise, returns the original string if it is null or empty.
        /// </returns>
        public static string ToCamelCase(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            string titleCase = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
            string camelCase = char.ToLowerInvariant(titleCase[0]) + titleCase.Substring(1).Replace(" ", "");
            return camelCase;
        }

        /// <summary>
        /// Converts a string to PascalCase. e.g. "hello world" becomes "HelloWorld".
        /// </summary>
        /// <param name="input">The input string to convert.</param>
        /// <returns>
        /// A PascalCase version of the input string, where the first letter of each word is capitalized and spaces are removed; 
        /// otherwise, returns the original string if it is null or empty.
        /// </returns>
        public static string ToPascalCase(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            string titleCase = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
            return titleCase.Replace(" ", "");
        }

        /// <summary>
        /// Converts a string to kebab-case. e.g. "Hello World" becomes "hello-world".
        /// </summary>
        /// <param name="input">The input string to convert.</param>
        /// <returns>
        /// A kebab-case version of the input string, where words are lowercase and separated by hyphens; 
        /// otherwise, returns the original string if it is null or empty.
        /// </returns>
        public static string ToKebabCase(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            var words = Regex.Matches(input, @"[A-Za-z][a-z]*|[0-9]+")
                .Cast<Match>() // cast to IEnumerable<Match>
                .Select(m => m.Value.ToLower());

            return string.Join("-", words);
        }

        /// <summary>
        /// Removes all whitespace (spaces, tabs, newlines) from the string.
        /// </summary>
        /// <param name="input">The input string to process.</param>
        /// <returns>
        /// A string with all whitespace characters removed; otherwise, returns the original string if it is null or empty.
        /// </returns>
        public static string RemoveWhitespace(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            return Regex.Replace(input, @"\s+", "");
        }

        /// <summary>
        /// Normalizes spaces — trims and replaces multiple spaces with a single space. e.g. "  Hello   World  " becomes "Hello World".
        /// </summary>
        /// <param name="input">The input string to normalize.</param> 
        /// <returns>
        /// A string with leading/trailing spaces removed and multiple spaces replaced by a single space;
        /// otherwise, returns the original string if it is null or empty.
        /// </returns>
        public static string NormalizeSpaces(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            return Regex.Replace(input.Trim(), @"\s+", " ");
        }

        /// <summary>
        /// Retrieves the value of the <see cref="DescriptionAttribute"/> applied to an enum value.
        /// If no description is found, it returns the enum's name as a fallback.
        /// </summary>
        /// <param name="value">The <see cref="Enum"/> value.</param>
        /// <returns>
        /// The description string or enum name if no description is present.
        /// </returns>
        public static string GetDescription(this Enum value)
        {
            if (value == null)
                return string.Empty;            // or "Unknown", or throw an ArgumentNullException

            var type  = value.GetType();        // get the type of the enum
            var name  = value.ToString();       // get the name of the enum value
            var field = type.GetField(name);    // get the field info for the enum value

            // if the field is null, it means the enum value does not exist in the type
            if (field == null)
                return name;

            // get the DescriptionAttribute applied to the field, if any
            var attribute = field.GetCustomAttribute<DescriptionAttribute>();

            // return the description if it exists, otherwise return the enum name
            return attribute?.Description ?? name;
        }

        /// <summary>
        /// Cleans a SQL query string by removing any zero-width characters and BOM.
        /// </summary>
        /// <param name="sql">The SQL query string to clean.</param>
        /// <returns>
        /// A cleaned SQL query string with zero-width characters and BOM removed; otherwise, returns the original string if it is null or empty.
        /// </returns>
        public static string ToCleanQueryString(this string sql)
        {
            if (string.IsNullOrEmpty(sql))
                return sql;

            // remove BOM and other zero-width characters
            return sql
                .Replace("\uFEFF", "")  // UTF-8 BOM / zero-width no-break space
                .Replace("\u200B", ""); // zero-width space
        }
    }
}
