namespace Notification.Application.Contracts;

public interface IGenericRepository<T>
    where T : class
{
    List<T> GetAll();
    bool Add(T item);
    bool Update(T item);
    bool Delete(T item);
    T GetById();
}
