using CinemaBooking.Infrastructure.Entities;
using CinemaBooking.Infrastructure.SearchFilters.AppUsersAggr;

namespace CinemaBooking.Infrastructure.Repositories.Abstract;

public interface IUsersRepository : IRepository<AppUser>
{
    public IEnumerable<AppUser> Search(AppUsersFilter filter);

    public AppUser? Get(SingleAppUserFilter filter);
}
