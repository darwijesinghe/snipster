using Newtonsoft.Json;
using System;
using System.IO;

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
        /// <param name="json">The JSON string to validate.</param>
        /// <returns>
        /// True if the string is a valid JSON; otherwise, false.
        /// </returns>
        public static bool IsValidJson(this string json)
        {
            if (string.IsNullOrWhiteSpace(json)) 
                return false;

            json = json.Trim();

            // quick check for JSON object or array
            if (!(json.StartsWith("{") && json.EndsWith("}")) && !(json.StartsWith("[") && json.EndsWith("]")))
                return false;

            try
            {
                // parse using JsonTextReader
                using var stringReader = new StringReader(json);
                using var jsonReader   = new JsonTextReader(stringReader);

                // fully parse JSON (no conversion)
                while (jsonReader.Read()) { }

                return true;
            }
            catch (JsonReaderException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
