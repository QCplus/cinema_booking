using CinemaBooking.Core.Dtos.MovieSessionsAggr;
using MediatR;

namespace CinemaBooking.Core.Commands.MovieSessionsAggr.SearchSessions;

public record SearchSessionsCommand(
    DateOnly? Day)
    : IRequest<IEnumerable<MovieSessionDto>>;
