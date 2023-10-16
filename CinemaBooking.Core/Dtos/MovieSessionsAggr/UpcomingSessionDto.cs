using CinemaBooking.Core.Dtos.MoviesAggr;
using CinemaBooking.Infrastructure.DS.SessionsAggr;

namespace CinemaBooking.Core.Dtos.MovieSessionsAggr;

public record UpcomingSessionDto(
    MovieDto Movie,
    IEnumerable<MovieSessionDto> Sessions
    )
{
    public static UpcomingSessionDto From(UpcomingSession session)
        => new(
            Movie: MovieDto.FromEntity(session.Movie),
            Sessions: MovieSessionDto.From(session.Sessions));

    public static IEnumerable<UpcomingSessionDto> From(IEnumerable<UpcomingSession> sessions)
        => sessions.Select(x => From(x));
}
