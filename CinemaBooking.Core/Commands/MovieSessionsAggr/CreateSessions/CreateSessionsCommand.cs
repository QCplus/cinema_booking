using MediatR;

namespace CinemaBooking.Core.Commands.MovieSessionsAggr.CreateSessions;

public record CreateSessionsCommand(
    DateOnly StartsFrom,
    DateOnly EndsAt,
    IEnumerable<DayOfWeek> Days,
    IEnumerable<TimeOnly> MovieStarts,
    int MovieId,
    int RoomId,
    decimal Price
    ) : IRequest;
