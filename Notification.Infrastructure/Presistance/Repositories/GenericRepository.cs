using Notification.Application.Contracts;

namespace Notification.Infrastructure.Presistance.Repositories;

public class GenericRepository<T> : IGenericRepository<T>
    where T : class
{

    private readonly AppDbContext _appDbContext;
    public GenericRepository(AppDbContext appDbContext)
        => _appDbContext = appDbContext;

    public bool Add(T item)
    {
        _appDbContext.Set<T>().Add(item);
        _appDbContext.SaveChanges();
        return true;
    }

    public bool Delete(T item)
    {
        throw new NotImplementedException();
    }

    public List<T> GetAll()
    {
        return _appDbContext.Set<T>().ToList();
    }

    public T GetById()
    {
        throw new NotImplementedException();
    }

    public bool Update(T item)
    {
        throw new NotImplementedException();
    }
}
