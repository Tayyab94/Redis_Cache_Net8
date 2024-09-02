using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace SpeedUpAPI_Redis.Services.CachingServices
{
    public class RedisService : IRedisService
    {
        private readonly IDistributedCache _cache;

        public RedisService(IDistributedCache cache)
        {
            this._cache = cache;

        }
        public T? GetData<T>(string key)
        {
            var data =_cache.GetString(key);    
            if (data is null)
                return default(T);

            return JsonSerializer.Deserialize<T>(data);

        }

        public void SetData<T>(string key, T value)
        {
            var option = new DistributedCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(60)
            };

            _cache?.SetString(key,JsonSerializer.Serialize(value), option);
        }
    }
}
