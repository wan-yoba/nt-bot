using Bot.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace Bot.Services;

public class CacheImplements(IMemoryCache memoryCache) : ICacheService
{
    public async Task SetCacheAsync<T>(string key, T value, TimeSpan expiration)
    {
        var options = new MemoryCacheEntryOptions()
        {
            AbsoluteExpirationRelativeToNow = expiration
        };

        memoryCache.Set(key, value, options);
        await Task.CompletedTask; // 如果需要异步操作，可以在这里做
    }

    public async Task<T?> GetCacheAsync<T>(string key)
    {
        if (memoryCache.TryGetValue(key, out T value))
        {
            return await Task.FromResult(value);
        }

        return await Task.FromResult(default(T)); // 没有缓存数据时，返回默认值
    }

    public async Task RemoveCacheAsync(string key)
    {
        memoryCache.Remove(key);
        await Task.CompletedTask;
    }
}