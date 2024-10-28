

namespace Notification.Application.Contracts;

public interface IRedisCacheService
{
    T? GetData<T>(string key);
    void SetData<T>(string key , T data);

}
