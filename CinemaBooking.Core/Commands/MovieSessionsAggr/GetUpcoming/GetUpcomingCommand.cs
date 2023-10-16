using CinemaBooking.Core.Dtos.MovieSessionsAggr;
using MediatR;

namespace CinemaBooking.Core.Commands.MovieSessionsAggr.GetUpcoming;

public record GetUpcomingCommand(
    int Count
    ) : IRequest<IEnumerable<UpcomingSessionDto>>;
