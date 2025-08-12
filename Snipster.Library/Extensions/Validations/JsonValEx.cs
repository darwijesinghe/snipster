using Newtonsoft.Json.Linq;

namespace Snipster.Library.Extensions.Validations
{
    /// <summary>
    /// Provides various extensions for validating JSON values.
    /// </summary>
    public static class JsonValEx
    {
        /// <summary>
        /// Validates if a string is a valid JSON format.
        /// </summary>
        /// <param name="json"> The JSON string to validate.</param>
        /// <returns>
        /// True if the string is a valid JSON; otherwise, false.
        /// </returns>
        public static bool IsValidJson(this string json)
        {
            if (string.IsNullOrWhiteSpace(json)) 
                return false;

            try
            {
                JToken.Parse(json); // parses any valid JSON (object, array, value)
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
