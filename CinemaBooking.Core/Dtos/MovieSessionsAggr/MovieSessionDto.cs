using CinemaBooking.Infrastructure.Entities;

namespace CinemaBooking.Core.Dtos.MovieSessionsAggr;

public record MovieSessionDto(
    int Id,
    DateTime StartsAt,
    decimal Price)
{
    public static MovieSessionDto From(MovieSession session)
        => new(
            Id: session.Id,
            StartsAt: session.StartsAt,
            Price: session.Price);

    public static IEnumerable<MovieSessionDto> From(IEnumerable<MovieSession> sessions)
        => sessions.Select(x => From(x));
}
