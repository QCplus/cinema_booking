using CinemaBooking.Infrastructure.DbContexts;
using CinemaBooking.Infrastructure.Entities;
using CinemaBooking.Infrastructure.Repositories.Abstract;

namespace CinemaBooking.Infrastructure.Repositories.EF;

internal sealed class MoviesRepository : IMoviesRepository
{
    private readonly AppDbContext _db;

    public MoviesRepository(AppDbContext db)
    {
        _db = db;
    }

    public int Create(Movie entity)
    {
        _db.Movies.Add(entity);

        _db.SaveChanges();

        return entity.Id;
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Movie? GetById(int id) => _db.Movies.Find(id);

    public void Update(Movie entity)
    {
        throw new NotImplementedException();
    }
}
