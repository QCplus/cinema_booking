namespace CinemaBooking.WebAPI.Models.Common;

public abstract class BaseFilter
{
    public int Page { get; set; }

    public int PerPageCount { get; set; } = 50;
}
