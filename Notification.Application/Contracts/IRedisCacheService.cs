

namespace Notification.Application.Contracts;

public interface IRedisCacheService
{
    T? GetData<T>(string key);
    void SetData<T>(string key , T data);
    void RemoveData(string key);

    Task<T?> GetDataAsync<T>(string key, CancellationToken ct = default);
    Task SetDataAsync<T>(string key, T data, CancellationToken ct = default);
    Task RemoveDataAsync(string key, CancellationToken ct = default);

}
