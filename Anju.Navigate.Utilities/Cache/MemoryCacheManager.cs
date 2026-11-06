using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;


namespace Anju.Navigation.Utilities
{
    public class MemoryCacheManager : ICacheManager
    {
        #region Properties
        ObjectCache cache = MemoryCache.Default;
        #endregion

        #region Methods
        public T GetCache<T>(string key)
        {
            var information = cache.Get(key);
            return (T)information;
        }

        public void SetCache(string key, object value)
        {
            CacheItemPolicy cacheItemPolicy = new CacheItemPolicy();
            cache.Add(key, value, cacheItemPolicy);
        }

        public void RemoveCache(string key)
        {
            cache.Remove(key);
        }

        public void ClearCache()
        {

            cache = MemoryCache.Default;
            List<string> cacheKeys = cache.Select(kvp => kvp.Key).ToList();
            foreach (string cacheKey in cacheKeys)
            {
                cache.Remove(cacheKey);
            }
        }
        #endregion
    }
}
