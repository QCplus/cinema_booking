namespace CinemaBooking.Infrastructure.Entities;

public class MovieTicket : BaseEntity
{
    public int MovieSessionId { get; set; }

    public int UserId { get; set; }

    public int SeatId { get; set; }
}
