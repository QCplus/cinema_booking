using CinemaBooking.Infrastructure.Entities;

namespace CinemaBooking.Core.Dtos.MoviesAggr;

public record MovieDto(
    int Id,
    string Name,
    int DurationMins,
    decimal? DefaultPrice)
{
    public static MovieDto FromEntity(Movie movie)
        => new(Id: movie.Id,
            Name: movie.Name,
            DurationMins: movie.DurationMins,
            DefaultPrice: movie.DefaultPrice
        );
}
