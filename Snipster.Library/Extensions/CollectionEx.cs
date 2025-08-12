using System;
using System.Collections.Generic;
using System.Linq;

namespace Snipster.Library.Extensions
{
    /// <summary>
    /// Provides various extensions for working with collections.
    /// </summary>
    public static class CollectionEx
    {
        /// <summary>
        /// Splits a collection into chunks of the specified size.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="source">The collection to split.</param>
        /// <param name="size">The size of each chunk.</param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> of chunks, where each chunk is an <see cref="IEnumerable{T}"/> containing elements from the original collection.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the <paramref name="source"/> collection is null or <paramref name="size"/> is less than or equal to zero.
        /// </exception>"
        public static IEnumerable<IEnumerable<T>> ChunkBy<T>(this IEnumerable<T> source, int size)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (size <= 0)
                throw new ArgumentOutOfRangeException(nameof(size));

            // create a new list to hold the current chunk.
            var chunk = new List<T>(size);

            // iterate through the source collection and add elements to the current chunk.
            foreach (var item in source)
            {
                // add the item to the current chunk.
                chunk.Add(item);
                if (chunk.Count == size)
                {
                    // yield the current chunk and reset it for the next set of items.
                    yield return chunk;

                    // create a new chunk for the next set of items.
                    chunk = new List<T>(size);
                }
            }

            // if there are any remaining items in the chunk, yield it.
            if (chunk.Any())
                yield return chunk;
        }

        /// <summary>
        /// Returns a dictionary from a list safely (skips duplicate keys).
        /// </summary>
        /// <typeparam name="TSource">The type of elements in the source collection.</typeparam>
        /// <typeparam name="TKey">The type of the key used for the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of the value used for the dictionary.</typeparam>
        /// <param name="source">The collection to convert.</param>
        /// <param name="keySelector">A function to extract the key from each element.</param>
        /// <param name="valueSelector">A function to extract the value from each element.</param>
        /// <returns>
        /// A <see cref="Dictionary{TKey, TValue}"/> containing elements from the collection, where duplicate keys are skipped.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the <paramref name="source"/>, <paramref name="keySelector"/>, or <paramref name="valueSelector"/> is null.
        /// </exception>"
        public static Dictionary<TKey, TValue> ToSafeDictionary<TSource, TKey, TValue>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TValue> valueSelector)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (keySelector == null)
                throw new ArgumentNullException(nameof(keySelector));
            if (valueSelector == null)
                throw new ArgumentNullException(nameof(valueSelector));

            var dict = new Dictionary<TKey, TValue>();
            foreach (var item in source)
            {
                var key = keySelector(item);
                if (!dict.ContainsKey(key))
                    dict[key] = valueSelector(item);
            }

            return dict;
        }

        /// <summary>
        /// Executes an action for each element in the collection.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="source">The collection to iterate over.</param>
        /// <param name="action">The action to execute for each element.</param>
        /// <returns>
        /// The original collection after executing the action for each element.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the <paramref name="source"/> or <paramref name="action"/> is null.
        /// </exception>
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            foreach (var item in source)
                action(item);
        }

        /// <summary>
        /// Returns a random element from a collection.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="source">The collection to select from.</param>
        /// <returns>
        /// A random element from the collection.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the <paramref name="source"/> is null.
        /// </exception>
        public static T RandomItem<T>(this IEnumerable<T> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            var list   = source.ToList();
            var random = new Random();
            var index  = random.Next(list.Count);

            return list[index];
        }

        /// <summary>
        /// Returns the most frequent item in the collection.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="source">The collection to analyze.</param>
        /// <returns>
        /// The most common item in the collection; otherwise, default if the collection is empty.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the <paramref name="source"/> is null.
        /// </exception>
        public static T MostCommon<T>(this IEnumerable<T> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return source
                .GroupBy(x => x)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .FirstOrDefault();
        }

        /// <summary>
        /// Returns the least frequent item in the collection.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="source">The collection to analyze.</param>
        /// <returns>
        /// The least common item in the collection; otherwise, default if the collection is empty.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the <paramref name="source"/> is null.
        /// </exception>
        public static T LeastCommon<T>(this IEnumerable<T> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return source
                .GroupBy(x => x)
                .OrderBy(g => g.Count())
                .Select(g => g.Key)
                .FirstOrDefault();
        }

        /// <summary>
        /// Compares two collections and returns elements only in the first.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collections.</typeparam>
        /// <param name="source">The first collection to compare.</param>
        /// <param name="other">The second collection to compare against.</param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> containing elements that are in the first collection but not in the second.
        /// </returns>
        public static IEnumerable<T> ExceptSafe<T>(this IEnumerable<T> source, IEnumerable<T> other)
        {
            return source?.Except(other ?? Enumerable.Empty<T>()) ?? Enumerable.Empty<T>();
        }

        /// <summary>
        /// Shuffles the collection randomly.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="source">The collection to shuffle.</param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> containing the elements of the original collection in random order.
        /// </returns>
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
        {
            if (source == null)
                return Enumerable.Empty<T>();

            return source.OrderBy(_ => Guid.NewGuid());
        }
    }
}
