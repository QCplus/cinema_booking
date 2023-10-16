using CinemaBooking.Infrastructure.Entities;
using MediatR;

namespace CinemaBooking.Core.Commands.MoviesAggr.CreateMovie;

public record CreateMovieCommand(
    string Name,
    int DurationMins,
    decimal? DefaultPrice)
    : IRequest<int>
{
    public Movie ToEntity()
        => new()
        {
            Name = Name,
            DurationMins = DurationMins,
            DefaultPrice = DefaultPrice
        };
}
