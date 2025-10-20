using System;
using System.Reflection;

namespace Snipster.Library.Extensions
{
    /// <summary>
    /// Provides various extensions for working with objects.
    /// </summary>
    public static class ObjectEx
    {
        /// <summary>
        /// Gets the value of a public instance property by name.
        /// </summary>
        /// <param name="obj">The object to retrieve the property value from.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns>
        /// The value of the property if found; otherwise, null.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the object is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when the property name is null or empty.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the property is not found or failed to get the value.
        /// </exception>
        public static object? GetPropertyValue(this object obj, string propertyName)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Property name cannot be null or empty.", nameof(propertyName));

            // gets the type of the object
            var type = obj.GetType();

            try
            {
                // gets the property using reflection
                var prop = type.GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);
                if (prop == null)
                    throw new InvalidOperationException($"Property '{propertyName}' not found on type '{type.Name}'.");

                return prop.GetValue(obj);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to get value of property '{propertyName}' on type '{type.Name}'.", ex);
            }
        }

        /// <summary>
        /// Sets the value of a public instance property by name, if it exists and is writable.
        /// </summary>
        /// <param name="obj">The object to retrieve the property value from.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="value">The value to set.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the object is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown when the property name is null or empty.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the property is not found or is read-only.
        /// </exception>
        /// <exception cref="InvalidCastException">
        /// Thrown when the value cannot be converted to the property's type.
        /// </exception>
        public static void SetPropertyValue(this object obj, string propertyName, object? value)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("Property name cannot be null or empty.", nameof(propertyName));

            // gets the property using reflection
            var type = obj.GetType();
            var prop = type.GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);
            if (prop == null || prop.SetMethod == null || !prop.SetMethod.IsPublic)
                throw new InvalidOperationException($"Property '{propertyName}' not found or is read-only on {obj.GetType().Name}.");

            // handles type conversion if needed
            var targetType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;

            try
            {
                object? convertedValue = value;

                if (value != null && !targetType.IsAssignableFrom(value.GetType()))
                {
                    // special case: enums
                    if (targetType.IsEnum)
                    {
                        if (value is string s)
                            convertedValue = Enum.Parse(targetType, s, ignoreCase: true);
                        else
                            convertedValue = Enum.ToObject(targetType, value);
                    }
                    // normal conversion
                    else
                    {
                        convertedValue = Convert.ChangeType(value, targetType);
                    }
                }

                prop.SetValue(obj, convertedValue);
            }
            catch (Exception ex)
            {
                throw new InvalidCastException($"Failed to set property '{propertyName}' on {type.Name}. Expected type {targetType.Name}.", ex);
            }
        }
    }
}
