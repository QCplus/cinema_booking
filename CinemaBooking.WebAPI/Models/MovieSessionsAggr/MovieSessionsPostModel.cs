using CinemaBooking.Core.Commands.MovieSessionsAggr.CreateSessions;

namespace CinemaBooking.WebAPI.Models.MovieSessionsAggr;

public class MovieSessionsPostModel
{
    public DateOnly StartsFrom { get; set; }

    public DateOnly EndsAt { get; set; }
    
    public IEnumerable<DayOfWeek> Days { get; set; } = Array.Empty<DayOfWeek>();

    public IEnumerable<TimeOnly> MovieStarts { get; set; } = Array.Empty<TimeOnly>();

    public int MovieId { get; set; }

    public int RoomId { get; set; }

    public decimal Price { get; set; }

    public CreateSessionsCommand ToCmd()
        => new(StartsFrom: StartsFrom,
                EndsAt: EndsAt,
                Days: Days,
                MovieId: MovieId,
                RoomId: RoomId,
                MovieStarts: MovieStarts,
                Price: Price);
}
