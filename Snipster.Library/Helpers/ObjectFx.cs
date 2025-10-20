using Newtonsoft.Json;
using System;

namespace Snipster.Library.Helpers
{
    /// <summary>
    /// A class that provides object-related utility functions.
    /// </summary>
    public static class ObjectFx
    {
        /// <summary>
        /// Creates a deep clone of the specified object using json serialization.
        /// </summary>
        /// <typeparam name="T">The object type to clone.</typeparam>
        /// <param name="obj">The source object to clone.</param>
        /// <returns>
        /// A deep cloned copy of the source object.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if the source object is null.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Thrown if a serialization or reference loop issue occurs or any unexpected error during cloning.
        /// </exception>
        public static T DeepClone<T>(this T obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj), "Object cannot be null when cloning.");

            try
            {
                // serializer settings for deep cloning
                var settings = new JsonSerializerSettings
                {
                    TypeNameHandling           = TypeNameHandling.All,              // include type names for polymorphic types
                    PreserveReferencesHandling = PreserveReferencesHandling.None,   // fully clone without reference IDs
                    ObjectCreationHandling     = ObjectCreationHandling.Replace,    // replace existing objects during deserialization
                    ReferenceLoopHandling      = ReferenceLoopHandling.Error,       // throw on circular references
                    NullValueHandling          = NullValueHandling.Include,         // handle nulls
                    DefaultValueHandling       = DefaultValueHandling.Include,      // handle defaults
                    Formatting                 = Formatting.None                    // compact json
                };

                var json = JsonConvert.SerializeObject(obj, settings);
                return JsonConvert.DeserializeObject<T>(json, settings)!;
            }
            catch (JsonException jex)
            {
                throw new InvalidOperationException
                    ($"Json error occurred while cloning type '{typeof(T).FullName}'.", jex);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException
                    ($"Unexpected error during deep clone for type '{typeof(T).FullName}'.", ex);
            }
        }
    }
}
