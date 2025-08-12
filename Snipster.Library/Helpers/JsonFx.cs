using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Snipster.Library.Helpers
{
    /// <summary>
    /// Provides methods for manipulating JSON strings.
    /// </summary>
    public static class JsonFx
    {
        /// <summary>
        /// Minifies a JSON string (removes all whitespace and newlines)
        /// </summary>
        /// <param name="json">The JSON string to minify.</param>
        /// <returns>
        /// A minified JSON string; if the input is invalid, returns the original string.
        /// </returns>
        public static string Minify(string json)
        {
            if (string.IsNullOrWhiteSpace(json)) 
                return json;

            try
            {
                var token = JToken.Parse(json);
                return token.ToString(Formatting.None);
            }
            catch
            {
                return json;
            }
        }

        /// <summary>
        /// Prettifies a JSON string (adds indentation and newlines for readability)
        /// </summary>
        /// <param name="json">The JSON string to prettify.</param>
        /// <returns>
        /// A prettified JSON string; if the input is invalid, returns the original string.
        /// </returns>
        public static string Prettify(string json)
        {
            if (string.IsNullOrWhiteSpace(json))
                return json;

            try
            {
                var token = JToken.Parse(json);
                return token.ToString(Formatting.Indented);
            }
            catch
            {
                return json;
            }
        }
    }
}
