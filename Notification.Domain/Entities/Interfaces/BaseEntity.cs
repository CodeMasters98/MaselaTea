namespace Notification.Domain.Entities.Interfaces;

public abstract class BaseEntity<T>
{
    public T Id { get; set; }
}
