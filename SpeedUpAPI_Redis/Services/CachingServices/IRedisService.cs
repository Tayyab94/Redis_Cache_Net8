namespace SpeedUpAPI_Redis.Services.CachingServices
{
    public interface IRedisService
    {
        T? GetData<T>(string key);
        void SetData<T>(string key, T value);
    }
}
