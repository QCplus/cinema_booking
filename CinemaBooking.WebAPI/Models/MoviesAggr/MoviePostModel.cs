using CinemaBooking.Core.Commands.MoviesAggr.CreateMovie;

namespace CinemaBooking.WebAPI.Models.MoviesAggr;

public class MoviePostModel
{
    public string Name { get; set; } = "";

    public int DurationMins { get; set; }

    public decimal? DefaultPrice { get; set; }

    public CreateMovieCommand ToCmd()
        => new(Name: Name,
               DurationMins: DurationMins,
               DefaultPrice: DefaultPrice);
}
