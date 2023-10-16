namespace CinemaBooking.Infrastructure.DS.Common;

public abstract class BaseDbFilter
{
    public int? Page { get; set; }

    public int? RowsPerPage { get; set; }
}
