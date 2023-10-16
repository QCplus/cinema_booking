namespace CinemaBooking.WebAPI.Models.SeatsAggr;

public class BookSeatsModel
{
    public string PaymentToken { get; set; } = "";

    public int RoomId { get; set; }

    public IEnumerable<int> SeatIndecies { get; set; } = Array.Empty<int>();
}
