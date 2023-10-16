using CinemaBooking.Core.Dtos.MovieSessionsAggr;
using CinemaBooking.WebAPI.Models.MoviesAggr;

namespace CinemaBooking.WebAPI.Models.MovieSessionsAggr;

public class UpcomingSessionModel
{
    public MovieModel Movie { get; set; }

    public IEnumerable<MovieSessionModel> Sessions { get; set; }

    public static UpcomingSessionModel FromDto(UpcomingSessionDto dto)
        => new()
        {
            Movie = MovieModel.FromDto(dto.Movie),
            Sessions = dto.Sessions.Select(s => MovieSessionModel.From(s))
        };

    public static IEnumerable<UpcomingSessionModel> FromDtos(IEnumerable<UpcomingSessionDto> dtos)
        => dtos.Select(x => FromDto(x));
}
