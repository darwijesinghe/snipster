using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Snipster.Library.Cache
{
    /// <summary>
    /// Provides an implementation of <see cref="ICacheService"/> that handles in-memory caching functionality.
    /// </summary>
    public sealed class CacheService : ICacheService
    {
        private readonly IMemoryCache          _cache;
        private readonly ILogger<CacheService> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="CacheService"/> class.
        /// </summary>
        /// <param name="cache">The in-memory cache instance.</param>
        /// <param name="logger">The logger instance for logging cache operations.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the logger is null.
        /// </exception>
        public CacheService(IMemoryCache cache, ILogger<CacheService> logger)
        {
            _cache  = cache;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <inheritdoc/>
        public async Task<T?> SetCacheAsync<T>(string key, Func<Task<T>> create) where T : class
        {
            return await LoadCacheAsync(key, 5, create);
        }

        /// <inheritdoc/>
        public async Task<T?> SetLongCacheAsync<T>(string key, Func<Task<T>> create) where T : class
        {
            return await LoadCacheAsync(key, 60, create);
        }

        /// <inheritdoc/>
        public async Task<T?> SetCacheAsync<T>(string key, double duration, Func<Task<T>> create) where T : class
        {
            return await LoadCacheAsync(key, duration, create);
        }

        /// <inheritdoc/>
        public void RemoveCache(string key)
        {
            if (_cache.TryGetValue(key, out _))
            {
                _cache.Remove(key);
                _logger.LogInformation("Cache entry with key '{CacheKey}' has been removed.", key);
            }
        }

        /// <summary>
        /// Loads data from the cache or fetches it using the provided function if not cached.
        /// Data is cached for the specified number of minutes.
        /// </summary>
        /// <typeparam name="T">The type of data to cache.</typeparam>
        /// <param name="internalKey">The cache key.</param>
        /// <param name="duration">Cache duration in minutes.</param>
        /// <param name="create">An asynchronous function to fetch data if not in cache.</param>
        /// <returns>
        /// The cached or newly fetched data; null on failure.
        /// </returns>
        private async Task<T?> LoadCacheAsync<T>(string internalKey, double duration, Func<Task<T>> create) where T : class
        {
            // try to get from cache
            if (_cache.TryGetValue(internalKey, out T data))
                return data;

            try
            {
                // fetch data via factory function
                data = await create();

                if (data is not null)
                {
                    _cache.Set(
                        internalKey,
                        data,
                        new MemoryCacheEntryOptions
                        {
                            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(duration)
                        }
                    );
                }

                return data;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while loading data for cache key '{CacheKey}'.", internalKey);
                return null;
            }
        }
    }
}
