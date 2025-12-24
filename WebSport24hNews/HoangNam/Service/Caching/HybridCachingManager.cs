using EasyCaching.Core;
using StackExchange.Redis;
using WebSport24hNews.HoangNam.Core.Infrastructure;
using WebSport24hNews.HoangNam.Service.Controller;

namespace WebSport24hNews.HoangNam.Service.Caching
{
    public class HybridCachingManager : IHybridCachingManager
    {
        private readonly IDatabase _db;

        private readonly IEasyCachingProviderFactory _factory;

        public IHybridCachingProvider HybridCachingProvider { get; }

        public IEasyCachingProvider Inmemory { get; }

        public IRedisCachingProvider Redis { get; }

        public bool IsConnectedRedis => _db.Multiplexer.IsConnected;

        public HybridCachingManager(IHybridProviderFactory hybridFactory, IDatabase db, IEasyCachingProviderFactory factory, IEasyCachingProvider inmemory, IRedisCachingProvider redis)
        {
            HybridCachingProvider = hybridFactory.GetHybridCachingProvider(CacheHelper.CacheConfig.ProviderNames.Hybrid);
            _db = db ?? throw new ArgumentNullException("db");
            _factory = factory;
            Inmemory = inmemory;
            Redis = redis;
        }

        public virtual T GetDb<T>(string key, Func<T> acquirer, int? cacheTime = null)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }

            TimeSpan expiration = cacheTime.HasValue && cacheTime.Value > 0 ? TimeSpan.FromMinutes(cacheTime.Value) : TimeSpan.FromMinutes(CachingDefaults.CacheTime);
            CacheValue<T> cacheValue = HybridCachingProvider.Get(key, acquirer, expiration);
            if (cacheValue.HasValue)
            {
                return cacheValue.Value;
            }

            return acquirer();
        }

        public virtual async Task<T> GetDbAsync<T>(string key, Func<Task<T>> acquirer, int? cacheTime = null)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("'key' cannot be null or empty.", "key");
            }

            TimeSpan duration = cacheTime.HasValue && cacheTime.Value > 0 ? TimeSpan.FromMinutes(cacheTime.Value) : TimeSpan.FromMinutes(CachingDefaults.CacheTime);
            CacheValue<T> cacheValue = await HybridCachingProvider.GetAsync(key, acquirer, duration);
            if (cacheValue.HasValue)
            {
                return cacheValue.Value;
            }

            return await acquirer();
        }

        public virtual async Task<T> GetDbAsync<T>(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("'key' cannot be null or empty.", "key");
            }

            return (await HybridCachingProvider.GetAsync<T>(key)).Value;
        }

        public virtual T GetDb<T>(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("'key' cannot be null or empty.", "key");
            }

            CacheValue<T> cacheValue = HybridCachingProvider.Get<T>(key);
            return cacheValue.Value;
        }

        public async Task<IEnumerable<string>> GetAllKeysMemoryCache(string prefix)
        {
            if (string.IsNullOrEmpty(prefix))
            {
                throw new ArgumentException("'prefix' cannot be null or empty.", "prefix");
            }

            IEasyCachingProvider provider = _factory.GetCachingProvider("localCache");
            if (provider == null)
            {
                throw new BaseException("Cache Redis is null !");
            }

            return await provider.GetAllKeysByPrefixAsync(prefix);
        }

        public async Task<IEnumerable<string>> GetAllKeysRedis(string prefix)
        {
            if (string.IsNullOrEmpty(prefix))
            {
                throw new ArgumentException("'prefix' cannot be null or empty.", "prefix");
            }

            IEasyCachingProvider provider = _factory.GetCachingProvider("redisCache");
            if (provider == null)
            {
                throw new BaseException("Cache InMemory is null !");
            }

            return await provider.GetAllKeysByPrefixAsync(prefix);
        }

        public async Task<T> GetDataRedis<T>(string prefix)
        {
            if (string.IsNullOrEmpty(prefix))
            {
                throw new ArgumentException("'prefix' cannot be null or empty.", "prefix");
            }

            IEasyCachingProvider provider = _factory.GetCachingProvider("redisCache");
            if (provider == null)
            {
                throw new BaseException("Cache Redis is null !");
            }

            return (await provider.GetAsync<T>(prefix)).Value;
        }

        public async Task<T> GetDataInMemory<T>(string prefix)
        {
            if (string.IsNullOrEmpty(prefix))
            {
                throw new ArgumentException("'prefix' cannot be null or empty.", "prefix");
            }

            IEasyCachingProvider provider = _factory.GetCachingProvider("localCache");
            if (provider == null)
            {
                throw new BaseException("Cache InMemory is null !");
            }

            return (await provider.GetAsync<T>(prefix)).Value;
        }

        public virtual async Task<T> GetDbInMemoryAsync<T>(string key, Func<Task<T>> acquirer, int? cacheTime = null)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("'key' cannot be null or empty.", "key");
            }

            IEasyCachingProvider provider = _factory.GetCachingProvider("localCache");
            if (provider == null)
            {
                throw new BaseException("Cache InMemory is null !");
            }

            TimeSpan duration = cacheTime.HasValue && cacheTime.Value > 0 ? TimeSpan.FromMinutes(cacheTime.Value) : TimeSpan.FromMinutes(CachingDefaults.CacheTime);
            CacheValue<T> cacheValue = await provider.GetAsync(key, acquirer, duration);
            if (cacheValue.HasValue)
            {
                return cacheValue.Value;
            }

            return await acquirer();
        }

        public virtual async Task<T> GetDbRedisAsync<T>(string key, Func<Task<T>> acquirer, int? cacheTime = null)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("'key' cannot be null or empty.", "key");
            }

            IEasyCachingProvider provider = _factory.GetCachingProvider("redisCache");
            if (provider == null)
            {
                throw new BaseException("Cache InMemory is null !");
            }

            TimeSpan duration = cacheTime.HasValue && cacheTime.Value > 0 ? TimeSpan.FromMinutes(cacheTime.Value) : TimeSpan.FromMinutes(CachingDefaults.CacheTime);
            CacheValue<T> cacheValue = await provider.GetAsync(key, acquirer, duration);
            if (cacheValue.HasValue)
            {
                return cacheValue.Value;
            }

            return await acquirer();
        }

    }
}
