using CinemaBooking.Core.Commands.MovieSessionsAggr.SearchSessions;
using CinemaBooking.WebAPI.Models.Common;

namespace CinemaBooking.WebAPI.Models.MovieSessionsAggr;

public class MovieSessionsFilter : BaseFilter
{
    public DateTime? Day { get; set; }

    public SearchSessionsCommand ToCmd()
        => new(Day: Day == null ? null : DateOnly.FromDateTime(Day.Value));
}
