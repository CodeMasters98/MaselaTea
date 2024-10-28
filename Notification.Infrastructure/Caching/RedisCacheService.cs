
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

    public void SetData<T>(string key, T data)
    {
        var options = new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5),
        };
        cache.SetString(key, JsonSerializer.Serialize(data), options);
        throw new NotImplementedException();
    }
}
