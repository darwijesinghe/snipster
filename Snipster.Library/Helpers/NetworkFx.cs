using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Web;

namespace Snipster.Library.Helpers
{
    /// <summary>
    /// A class that provides network-related functionality.
    /// </summary>
    public static class NetworkFx
    {
        /// <summary>
        /// Checks if a host is available by sending a ping request.
        /// </summary>
        /// <param name="host">The host to check.</param>
        /// <param name="timeout">The timeout in milliseconds for the ping request. Defaults to 1000 milliseconds (1 second).</param>
        /// <returns>
        /// True if the host is available, otherwise false.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown when the host is null or empty.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when the timeout is less than or equal to zero.
        /// </exception>
        public static async Task<bool> IsHostAvailableAsync(string host, int timeout = 1000)
        {
            if (string.IsNullOrWhiteSpace(host))
                throw new ArgumentException("Host cannot be null or empty.", nameof(host));
            if (timeout <= 0)
                throw new ArgumentOutOfRangeException(nameof(timeout), "Timeout must be a positive integer.");

            using var ping = new Ping();
            var reply      = await ping.SendPingAsync(host, timeout);

            return reply.Status == IPStatus.Success;
        }

        /// <summary>
        /// Builds a URL with query parameters from a base URL and a dictionary of parameters. Supports both single values and collections as parameter values.
        /// </summary>
        /// <param name="baseUrl">The base URL to which the parameters will be added.</param>
        /// <param name="parameters">A dictionary containing the query parameters to be added to the URL.</param>
        /// <returns>
        /// A string representing the complete URL with the query parameters appended.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown when the base URL is null or empty.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the parameters dictionary is null.
        /// </exception>
        public static string BuildUrl(string baseUrl, Dictionary<string, object?> parameters)
        {
            if (string.IsNullOrWhiteSpace(baseUrl))
                throw new ArgumentException("Base URL cannot be null or empty.", nameof(baseUrl));
            if (parameters == null)
                throw new ArgumentNullException(nameof(parameters), "Parameters cannot be null.");

            var uriBuilder = new UriBuilder(baseUrl);
            var query      = HttpUtility.ParseQueryString(uriBuilder.Query);

            foreach (var kvp in parameters)
            {
                if (kvp.Value == null) continue;

                // handle lists/arrays
                if (kvp.Value is IEnumerable enumerable && kvp.Value is not string)
                {
                    foreach (var item in enumerable)
                    {
                        if (item != null)
                            query.Add(kvp.Key, item.ToString());
                    }
                }
                else
                {
                    query[kvp.Key] = kvp.Value.ToString();
                }
            }

            uriBuilder.Query = query.ToString() ?? string.Empty;
            var uri          = uriBuilder.Uri;

            // removes default ports from final URL
            if ((uri.Scheme == Uri.UriSchemeHttps && uri.Port == 443) ||
                (uri.Scheme == Uri.UriSchemeHttp && uri.Port == 80))
            {
                return $"{uri.Scheme}://{uri.Host}{uri.PathAndQuery}";
            }

            return uri.AbsoluteUri;
        }
    }
}
