using CinemaBooking.Core.Dtos.MoviesAggr;

namespace CinemaBooking.WebAPI.Models.MoviesAggr;

public class MovieModel
{
    public int Id { get; set; }

    public string Name { get; set; } = "";

    public int DurationMins { get; set; }

    public decimal? DefaultPrice { get; set; }

    public static MovieModel FromDto(MovieDto dto)
        => new()
        {
            Id = dto.Id,
            Name = dto.Name,
            DurationMins = dto.DurationMins,
            DefaultPrice = dto.DefaultPrice,
        };
}
