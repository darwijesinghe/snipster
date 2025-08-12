using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Snipster.Library.Helpers
{
    /// <summary>
    /// Provides various security-related helper methods and functionalities.
    /// </summary>
    public static class SecurityFx
    {
        /// <summary>
        /// Generates a random string of specified length using allowed characters.
        /// </summary>
        /// <param name="length">The length of the random string to generate.</param>
        /// <param name="allowedChars">A string containing characters that can be used in the random string.</param>
        /// <returns>
        /// A random string of the specified <paramref name="length"/> composed of characters from the <paramref name="allowedChars"/> string.
        /// </returns>
        public static string RandomString(int length = 32, string allowedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789")
        {
            var rnd = new Random();
            return new string(Enumerable.Repeat(allowedChars, length).Select(s => s[rnd.Next(s.Length)]).ToArray());
        }

        /// <summary>
        /// Generates a secure random token of specified length using cryptographic random number generation.
        /// </summary>
        /// <param name="length">The length of the token to generate. Default is 32 characters.</param>
        /// <returns>
        /// A secure random token as a Base64 string, with URL-safe characters and trimmed to the specified length.
        /// </returns>
        public static string GenerateSecureToken(int length = 32)
        {
            using var rng = RandomNumberGenerator.Create();
            var bytes     = new byte[length];

            // fill the byte array with cryptographically strong random bytes
            rng.GetBytes(bytes);

            // convert to Base64 and remove characters that are not URL-safe
            return Convert.ToBase64String(bytes).Replace("+", "").Replace("/", "").Replace("=", "").Substring(0, length);
        }

        /// <summary>
        /// Generates a hashed password and salt using HMACSHA256.
        /// </summary>
        /// <param name="password">The plain text password to hash.</param>
        /// <param name="passwordHash">The resulting hashed password as a byte array.</param>
        /// <param name="passwordSalt">The generated salt used for hashing as a byte array.</param>
        public static void PasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            // create a new instance of HMACSHA256 to generate a hash for the password
            using (var hmac = new HMACSHA256())
            {
                // generate a cryptographic key (salt) for the HMAC algorithm
                passwordSalt = hmac.Key;

                // compute the hash of the input password (converted to bytes using UTF-8 encoding)
                // this ensures the password is stored in a secure hashed format
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        /// <summary>
        /// Verifies if the provided password matches the stored password hash using the provided salt.
        /// </summary>
        /// <param name="password">The plain text password to verify.</param>
        /// <param name="passwordHash">The stored hashed password as a byte array.</param>
        /// <param name="passwordSalt">The salt used to hash the stored password.</param>
        /// <returns>
        /// Returns true if the password is valid; otherwise, false.
        /// </returns>
        public static bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            // use the HMACSHA256 algorithm to generate a hash from the password, using the provided salt
            using (var hmac = new HMACSHA256(passwordSalt))
            {
                // compute the hash of the input password (converting the plain text password to bytes)
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                // compare the computed hash with the stored password hash to check if they are the same
                // sequenceEqual checks if each byte in both arrays matches
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
