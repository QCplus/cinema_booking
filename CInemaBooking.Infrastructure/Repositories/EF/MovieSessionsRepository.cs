using CinemaBooking.Infrastructure.DbContexts;
using CinemaBooking.Infrastructure.DS.SessionsAggr;
using CinemaBooking.Infrastructure.Entities;
using CinemaBooking.Infrastructure.Repositories.Abstract;

namespace CinemaBooking.Infrastructure.Repositories.EF;

internal class MovieSessionsRepository : IMovieSessionsRepository
{
    private readonly AppDbContext _db;

    public MovieSessionsRepository(AppDbContext db)
    {
        _db = db;
    }

    public int Create(MovieSession entity)
    {
        throw new NotImplementedException();
    }

    public void Create(DateOnly startsFrom, DateOnly endsAt, IEnumerable<DayOfWeek> days, IEnumerable<TimeOnly> movieStarts,
        int movieId, int roomId, decimal price)
    {
        for (DateOnly dt = startsFrom; dt <= endsAt; dt = dt.AddDays(1))
        {
            if (!days.Contains(dt.DayOfWeek))
                continue;

            foreach (TimeOnly time in movieStarts)
            {
                var session = new MovieSession()
                {
                    MovieId = movieId,
                    RoomId = roomId,
                    Price = price,
                    StartsAt = startsFrom.ToDateTime(time, DateTimeKind.Utc),
                };

                _db.MovieSessions.Add(session);
            }
        }

        _db.SaveChanges();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public MovieSession? GetById(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<UpcomingSession> GetUpcoming(int count)
    {
        var sessions = _db.MovieSessions
            .Where(s => s.StartsAt > DateTime.UtcNow)
            .OrderBy(s => s.StartsAt)
            .Join(_db.Movies, x => x.MovieId, y => y.Id, (x, y) => new { Session = x, Movie = y })
            .Take(count);
            //.ToList();

        return sessions
            .Select(x => new UpcomingSession()
            {
                Movie = x.Movie,
                Sessions = new List<MovieSession> { x.Session }
            });
    }

    public void Update(MovieSession entity)
    {
        throw new NotImplementedException();
    }
}
