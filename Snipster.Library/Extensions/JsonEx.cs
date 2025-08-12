using Newtonsoft.Json;

namespace Snipster.Library.Extensions
{
    /// <summary>
    /// Provides various extensions for working with JSON data.
    /// </summary>
    public static class JsonEx
    {
        /// <summary>
        /// Serializes the specified object to a JSON string.
        /// </summary>
        /// <param name="obj">The object to serialize.</param>
        /// <param name="formatting">Optional formatting for the JSON output (None or Indented). Default is None.</param>
        /// <returns>
        /// A JSON-formatted string representation of the object; otherwise, returns an empty string if the object is null.
        /// </returns>
        public static string ToJson(this object obj, Formatting formatting = Formatting.None)
        {
            return obj == null ? string.Empty : JsonConvert.SerializeObject(obj, formatting);
        }

        /// <summary>
        /// De-serializes a JSON string to an object of type T.
        /// </summary>
        /// <typeparam name="T">The type of the object to de-serialize to.</typeparam>
        /// <param name="json">The JSON string to de-serialize.</param>
        /// <returns>
        /// An object of type T if the JSON is valid; otherwise, returns default(T).
        /// </returns>
        public static T? FromJson<T>(this string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch
            {
                return default;
            }
        }
    }
}
