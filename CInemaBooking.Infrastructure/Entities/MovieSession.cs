namespace CinemaBooking.Infrastructure.Entities;

public class MovieSession : BaseEntity
{
    public DateTime StartsAt { get; set; }

    public decimal Price { get; set; }

    public Movie? Movie { get; set; }
    public int MovieId { get; set; }

    public Room? Room { get; set; }
    public int RoomId { get; set; }
}
