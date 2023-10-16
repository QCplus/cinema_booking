using CinemaBooking.Infrastructure.DbContexts;
using CinemaBooking.Infrastructure.Entities;
using CinemaBooking.Infrastructure.Repositories.Abstract;

namespace CinemaBooking.Infrastructure.Repositories.EF;

internal sealed class RoomsRepository : IRoomsRepository
{
    private readonly AppDbContext _db;

    public RoomsRepository(AppDbContext db)
    {
        _db = db;
    }

    public int Create(Room entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Room? GetById(int id) => _db.Rooms.Find(id);

    public void Update(Room entity)
    {
        throw new NotImplementedException();
    }
}
