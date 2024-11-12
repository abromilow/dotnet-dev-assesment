using DeveloperAssesment.Core.Caching.Services.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace DeveloperAssesment.Core.Caching.Services
{
    public class CachingService : ICacheService
    {
        private readonly IMemoryCache _cache;

        public CachingService(IMemoryCache cache)
        {
            _cache = cache;
        }

        public async Task<T?> GetOrCreateAsync<T>(
        string cacheKey,
        Func<Task<T>> retrieveDataFunc,
        TimeSpan? slidingExpiration = null)
        {
            if (!_cache.TryGetValue(cacheKey, out T? cachedData))
            {
                // Data not in cache, retrieve it
                cachedData = await retrieveDataFunc();

                // Set cache options
                var cacheEntryOptions = new MemoryCacheEntryOptions
                {
                    SlidingExpiration = slidingExpiration ?? TimeSpan.FromMinutes(60)
                };

                // Save data in cache
                _cache.Set(cacheKey, cachedData, cacheEntryOptions);
            }

            return cachedData;
        }

        public bool DeleteCache(string cacheKey)
        {
            try
            {
                _cache.Remove(cacheKey);

            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
