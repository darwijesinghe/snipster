using System;
using System.Net;

namespace Snipster.Library.Extensions.Validations
{
    /// <summary>
    /// Provides various extensions for validating network-related values.
    /// </summary>
    public static class NetworkValEx
    {
        /// <summary>
        /// Validates if a given string is a valid IPv4 address.
        /// </summary>
        /// <param name="input">The input string to validate.</param>
        /// <returns>
        /// True if the string is a valid IPv4 address; otherwise, false.
        /// </returns>
        public static bool IsValidIPv4(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            return IPAddress.TryParse(input, out var address) && address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork;
        }

        /// <summary>
        /// Validates if a given string is a valid IPv6 address.
        /// </summary>
        /// <param name="input">The input string to validate.</param>
        /// <returns>
        /// True if the string is a valid IPv6 address; otherwise, false.
        /// </returns>
        public static bool IsValidIPv6(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            return IPAddress.TryParse(input, out var address) && address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6;
        }

        /// <summary>
        /// Validates if a given string is a valid web address (HTTP or HTTPS).
        /// </summary>
        /// <param name="input">The input string to validate.</param>
        /// <returns>
        /// True if the string is a valid web address (HTTP or HTTPS); otherwise, false.
        /// </returns>
        public static bool IsValidWebAddress(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            if (Uri.TryCreate(input, UriKind.Absolute, out var uriResult))
            {
                return uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps;
            }

            return false;
        }
    }
}
