using System;
using System.Collections.Generic;
using System.Reflection;

namespace Snipster.Library.Extensions.Validations
{
    /// <summary>
    /// Provides various extensions for validating objects.
    /// </summary>
    public static class ObjectValEx
    {
        /// <summary>
        /// Determines whether the specified object is equal to its type's default value.
        /// </summary>
        /// <param name="obj">The object to check.</param>
        /// <returns>
        /// True if the object is equal to its type's default value; otherwise, false.
        /// </returns>
        public static bool IsDefaultValue<T>(this T obj)
        {
            // if null → it's default
            if (obj == null)
                return true;

            var type = typeof(T);

            // handle nullable types (Nullable<T> behaves differently)
            if (Nullable.GetUnderlyingType(type) != null)
            {
                var underlying   = Nullable.GetUnderlyingType(type)!;
                var defaultValue = Activator.CreateInstance(underlying);

                return Equals(obj, defaultValue);
            }

            // value type vs reference type comparison
            var defaultInstance = default(T);
            return EqualityComparer<T>.Default.Equals(obj, defaultInstance!);
        }

        /// <summary>
        /// Checks whether the given object has a property with the specified name.
        /// </summary>
        /// <param name="obj">The object to check.</param>
        /// <param name="propertyName">The name of the property to look for.</param>
        /// <returns>
        /// True if the object has a property with the specified name; otherwise, false.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the object is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when the property name is null or empty.
        /// </exception>
        public static bool HasProperty(this object obj, string propertyName)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Property name cannot be null or empty.", nameof(propertyName));

            var type = obj.GetType();

            // check for the property using reflection
            var prop = type.GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);
            return prop != null;
        }
    }
}
