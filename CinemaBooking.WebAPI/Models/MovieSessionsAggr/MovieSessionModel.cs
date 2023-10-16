using CinemaBooking.Core.Dtos.MovieSessionsAggr;

namespace CinemaBooking.WebAPI.Models.MovieSessionsAggr;

public class MovieSessionModel
{
    public int Id { get; set; }

    public DateTime StartsAt { get; set; }

    public decimal Price { get; set; }

    public static MovieSessionModel From(MovieSessionDto dto)
        => new()
        {
            Id = dto.Id,
            Price = dto.Price,
            StartsAt = dto.StartsAt,
        };

    public static IEnumerable<MovieSessionModel> From(IEnumerable<MovieSessionDto> dtos)
        => dtos.Select(x => From(x));
}
