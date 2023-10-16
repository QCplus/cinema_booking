using CinemaBooking.Infrastructure.DS.Common;

namespace CinemaBooking.Infrastructure.DS.SessionsAggr;

public class SessionsFilter : BaseDbFilter
{
    public DateOnly? Day { get; set; }
}
