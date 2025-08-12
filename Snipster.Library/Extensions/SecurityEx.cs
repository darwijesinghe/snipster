using System.Security.Cryptography;
using System.Text;

namespace Snipster.Library.Extensions
{
    /// <summary>
    /// Provides various extensions for working with security-related operations.
    /// </summary>
    public static class SecurityEx
    {
        /// <summary>
        /// Generates a SHA256 hash from a string. Useful for creating unique identifiers or checksums.
        /// </summary>
        /// <param name="input">The input string to hash.</param>
        /// <returns>
        /// A SHA256 hash of the input string, represented as a hexadecimal string; otherwise, returns the 
        /// original string if it is null or empty.
        /// </returns>
        public static string ToSha256(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            using var sha = SHA256.Create();                // create a new SHA256 instance
            var bytes     = Encoding.UTF8.GetBytes(input);  // convert the input string to bytes using UTF8 encoding
            var hash      = sha.ComputeHash(bytes);         // compute the hash of the byte array

            var sb        = new StringBuilder();

            foreach (var b in hash)
                sb.Append(b.ToString("x2"));                // lowercase hex

            return sb.ToString();
        }
    }
}
