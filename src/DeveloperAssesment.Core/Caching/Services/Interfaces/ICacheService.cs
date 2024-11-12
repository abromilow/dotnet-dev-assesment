using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperAssesment.Core.Caching.Services.Interfaces
{
    public interface ICacheService
    {
        Task<T?> GetOrCreateAsync<T>(
            string cacheKey,
            Func<Task<T>> retrieveDataFunc,
            TimeSpan? slidingExpiration = null);

        Task<bool> DeleteCache(string cacheKey);
    }
}
