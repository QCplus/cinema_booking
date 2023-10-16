using CinemaBooking.Infrastructure.DS.SessionsAggr;
using CinemaBooking.Infrastructure.Entities;

namespace CinemaBooking.Infrastructure.Repositories.Abstract;

public interface IMovieSessionsRepository : IRepository<MovieSession>
{
    public void Create(DateOnly startsFrom, DateOnly endsAt, IEnumerable<DayOfWeek> days, IEnumerable<TimeOnly> movieStarts,
        int movieId, int roomId, decimal price);

    public IEnumerable<UpcomingSession> GetUpcoming(int count);
}
