using CinemaBooking.Infrastructure.Entities;

namespace CinemaBooking.Infrastructure.DS.SessionsAggr;

public class UpcomingSession
{
    public Movie Movie { get; set; }

    public IEnumerable<MovieSession> Sessions { get; set; }
}
