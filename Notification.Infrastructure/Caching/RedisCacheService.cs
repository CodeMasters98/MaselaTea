
using Microsoft.EntityFrameworkCore.Storage.Json;
using Microsoft.Extensions.Caching.Distributed;
using Notification.Application.Contracts;
using System.Text.Json;

namespace Notification.Infrastructure.Caching;
public class RedisCacheService(IDistributedCache cache) 
    : IRedisCacheService
{

    public T? GetData<T>(string key)
    {
        var data =  cache.GetString(key);
        if (data == null)
            return default(T);

        return JsonSerializer.Deserialize<T>(data);
    }

    public async Task<T?> GetDataAsync<T>(string key, CancellationToken ct = default)
    {
        var data = await cache.GetStringAsync(key, ct);
        if (data == null)
            return default(T);

        return JsonSerializer.Deserialize<T>(data);
    }

    public void RemoveData(string key)
    {
        cache.Remove(key);
    }

    public async Task RemoveDataAsync(string key, CancellationToken ct = default)
    {
        await cache.RemoveAsync(key, ct);
    }

    public void SetData<T>(string key, T data)
    {
        var options = new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5),
        };
        cache.SetString(key, JsonSerializer.Serialize(data), options);
    }

    public async Task SetDataAsync<T>(string key, T data, CancellationToken ct = default)
    {
        var options = new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5),
        };
        await cache.SetStringAsync(key, JsonSerializer.Serialize(data), options, ct);
    }
}
