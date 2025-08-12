using System;
using System.Threading.Tasks;

namespace Snipster.Library.Cache
{
    /// <summary>
    /// Defines a contract for a caching service that provides methods to store, retrieve, and manage cached data.
    /// </summary>
    public interface ICacheService
    {
        /// <summary>
        /// Retrieves data from the cache or loads it using the provided function if not cached.
        /// Data is cached for 5 minutes.
        /// </summary>
        /// <typeparam name="T">The type of data to cache.</typeparam>
        /// <param name="key">The cache key.</param>
        /// <param name="create">An asynchronous function to fetch data if not in cache.</param>
        /// <returns>
        /// The cached or newly fetched data; null on failure.
        /// </returns>
        Task<T?> SetCacheAsync<T>(string key, Func<Task<T>> create) where T : class;

        /// <summary>
        /// Retrieves data from the cache or loads it using the provided function if not cached.
        /// Data is cached for 60 minutes.
        /// </summary>
        /// <typeparam name="T">The type of data to cache.</typeparam>
        /// <param name="key">The cache key.</param>
        /// <param name="create">An asynchronous function to fetch data if not in cache.</param>
        /// <returns>
        /// The cached or newly fetched data; null on failure.
        /// </returns>
        Task<T?> SetLongCacheAsync<T>(string key, Func<Task<T>> create) where T : class;

        /// <summary>
        /// Retrieves data from the cache or loads it using the provided function if not cached.
        /// </summary>
        /// <typeparam name="T">The type of data to cache.</typeparam>
        /// <param name="key">The cache key.</param>
        /// <param name="duration">Cache duration in minutes.</param>
        /// <param name="create">An asynchronous function to fetch data if not in cache.</param>
        /// <returns>
        /// The cached or newly fetched data; null on failure.
        /// </returns>
        Task<T?> SetCacheAsync<T>(string key, double duration, Func<Task<T>> create) where T : class;

        /// <summary>
        /// Removes a specific entry from the cache.
        /// </summary>
        /// <param name="key">The cache key to remove.</param>
        void RemoveCache(string key);
    }
}
