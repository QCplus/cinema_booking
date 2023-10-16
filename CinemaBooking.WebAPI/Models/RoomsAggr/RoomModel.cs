using CinemaBooking.Core.Dtos.RoomsAggr;

namespace CinemaBooking.WebAPI.Models.RoomsAggr;

public class RoomModel
{
    public int Id { get; set; }

    public string Name { get; set; } = "";

    public string? Description { get; set; } = "";

    public static RoomModel FromDto(RoomDto room)
    {
        return new()
            {
                Id = room.Id,
                Name = room.Name,
                Description = room.Description,
            };
    }
}
