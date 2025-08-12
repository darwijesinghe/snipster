using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Moq;
using Snipster.Library.Cache;

namespace Snipster.Test.Cache
{
    /// <summary>
    /// Tests for the Cache class.
    /// </summary>
    [TestClass]
    public class CacheTest
    {
        private readonly IMemoryCache                _memoryCache;
        private readonly Mock<ILogger<CacheService>> _loggerMock;
        private readonly ICacheService               _cacheService;

        public CacheTest()
        {
            // create a mock logger for the CacheService
            _loggerMock   = new Mock<ILogger<CacheService>>();

            // create an in-memory cache instance
            _memoryCache  = new MemoryCache(new MemoryCacheOptions());

            // initialize the CacheService with the mock logger and in-memory cache
            _cacheService = new CacheService(_memoryCache, _loggerMock.Object);
        }

        /// <summary>
        /// Tests the SetCacheAsync method of the CacheService to ensure it caches data correctly.
        /// </summary>
        [TestMethod]
        public async Task SetCacheAsync_ShouldReturnCachedData()
        {
            // Arrange
            string key   = "test-key";
            string value = "testValue";

            // Act
            var result = await _cacheService.SetCacheAsync(key, () => Task.FromResult(value));

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(value, result);
        }

        /// <summary>
        /// Tests the SetCacheAsync method of the CacheService to ensure it caches data for a specified duration.
        /// </summary>
        [TestMethod]
        public async Task SetCacheAsync_ShouldExpireAfterDuration()
        {
            // Arrange
            string key   = "duration-test-key";
            string value = "durationTestValue";
            int duration = 1; // 1 sec

            // Act
            var result = await _cacheService.SetCacheAsync(key, (double)duration / 60, () => Task.FromResult(value));

            // Assert immediately
            Assert.IsNotNull(result);
            Assert.AreEqual(value, result);

            // wait for expiration
            await Task.Delay(TimeSpan.FromSeconds(duration + 1));

            // try to get again (should trigger new fetch)
            string newValue = "new";
            var refreshed   = await _cacheService.SetCacheAsync(key, duration, () => Task.FromResult(newValue));

            // Assert that the cache has expired and a new value is returned
            Assert.AreEqual(newValue, refreshed);
        }

        /// <summary>
        /// Tests the SetLongCacheAsync method of the CacheService to ensure it caches data for a longer duration.
        /// </summary>
        [TestMethod]
        public async Task SetLongCacheAsync_ShouldReturnCachedData()
        {
            // Arrange
            string key   = "long-test-key";
            string value = "longTestValue";

            // Act
            var result = await _cacheService.SetLongCacheAsync(key, () => Task.FromResult(value));

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(value, result);
        }

        /// <summary>
        /// Tests the SetCacheAsync method of the CacheService to ensure it returns cached data if it already exists.
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task SetCacheAsync_ShouldReturnCachedDataIfExists()
        {
            // Arrange
            string key      = "existing-key";
            string value    = "cachedValue";
            string newValue = "newCachedValue";

            // pre-populate the cache with an existing value
            _memoryCache.Set(key, value);

            // Act
            var result = await _cacheService.SetCacheAsync(key, () => Task.FromResult(newValue));

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(value, result);
        }

        /// <summary>
        /// Tests the RemoveCache method of the CacheService to ensure it removes a specific cache entry.
        /// </summary>
        [TestMethod]
        public void RemoveCache_ShouldRemoveCache()
        {
            // Arrange
            string key   = "removal-key";
            string value = "valueToRemove";

            // pre-populate the cache with a value
            _memoryCache.Set(key, value);

            // Act
            _cacheService.RemoveCache(key);
            var cached = _memoryCache.Get<string>(key);

            // Assert

            Assert.IsNull(cached);
        }
    }
}
