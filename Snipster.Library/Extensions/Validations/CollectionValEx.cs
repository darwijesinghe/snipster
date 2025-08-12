using System.Collections.Generic;
using System.Linq;

namespace Snipster.Library.Extensions.Validations
{
    /// <summary>
    /// Provides various extensions for validating collections.
    /// </summary>
    public static class CollectionValEx
    {
        /// <summary>
        /// Returns true if the collection is null or has no elements.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="source">The collection to check.</param>
        /// <returns>
        /// True if the collection is null or has no elements; otherwise, false.
        /// </returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
        {
            return source == null || !source.Any();
        }

        /// <summary>
        /// Returns true if the collection contains any duplicates.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="source">The collection to check for duplicates.</param>
        /// <returns>
        /// True if the collection contains duplicates; otherwise, false.
        /// </returns>
        public static bool HasDuplicates<T>(this IEnumerable<T> source)
        {
            return source.GroupBy(x => x).Any(g => g.Count() > 1);
        }
    }
}
