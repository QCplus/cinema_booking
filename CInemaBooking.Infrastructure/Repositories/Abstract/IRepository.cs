namespace CinemaBooking.Infrastructure.Repositories.Abstract;

public interface IRepository<T>
{
    public T? GetById(int id);

    public int Create(T entity);

    public void Delete(int id);

    public void Update(T entity);
}
