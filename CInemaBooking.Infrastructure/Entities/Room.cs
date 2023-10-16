namespace CinemaBooking.Infrastructure.Entities;

public class Room : BaseEntity
{
    public string Name { get; set; } = "";

    public string? Description { get; set; }

    public int Rows { get; set; }

    public int Columns { get; set; }

    public ICollection<BookedSeat> BookedSeats { get; set; } = Array.Empty<BookedSeat>();

    public ICollection<MovieSession> MovieSessions { get; set; } = Array.Empty<MovieSession>();
}
