using CinemaBooking.Infrastructure.DbContexts;
using CinemaBooking.Infrastructure.Entities;
using CinemaBooking.Infrastructure.Extensions;
using CinemaBooking.Infrastructure.Repositories.Abstract;
using CinemaBooking.Infrastructure.SearchFilters.AppUsersAggr;

namespace CinemaBooking.Infrastructure.Repositories.EF;

internal sealed class UsersRepository : IUsersRepository
{
    private readonly AppDbContext _db;

    public UsersRepository(AppDbContext db)
    {
        _db = db;
    }

    public int Create(AppUser entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public AppUser? GetById(int id) => _db.Users.Find(id);

    public void Update(AppUser entity)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<AppUser> Search(AppUsersFilter filter)
    {
        return _db.Users
            .WhereIfNotNull(filter.Phone, u => u.Phone.Contains(filter.Phone!))
            .WhereIfNotNull(filter.FirstName, u => u.FirstName.Contains(filter.FirstName!))
            .WhereIfNotNull(filter.LastName, u => u.LastName.Contains(filter.LastName!))
            .WhereIfNotNull(filter.Email, u => u.Email.Contains(filter.Email!))
            .WhereIfNotNull(filter.RoleId, u => u.RoleId == filter.RoleId);
    }

    public AppUser? Get(SingleAppUserFilter filter)
    {
        return _db.Users
            .WhereIfNotNull(filter.Phone, u => u.Phone == filter.Phone)
            .WhereIfNotNull(filter.Email, u => u.Email == filter.Email)
            .WhereIfNotNull(filter.Nickname, u => u.Nickname == filter.Nickname)
            .FirstOrDefault();
    }
}
