namespace CinemaBooking.Infrastructure.Entities;

public class Movie : BaseEntity
{
    public string Name { get; set; } = "";

    public int DurationMins { get; set; }

    public decimal? DefaultPrice { get; set; }

    public ICollection<MovieSession> MovieSessions { get; set; } = Array.Empty<MovieSession>();
}
