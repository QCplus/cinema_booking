namespace CinemaBooking.Infrastructure.Entities;

public class BookedSeat : BaseEntity
{
    public int RoomId { get; set; }

    public int Index { get; set; }

    public Room Room { get; set; }
}
