using CinemaBooking.Infrastructure.Entities;

namespace CinemaBooking.Core.Dtos.RoomsAggr;

public record RoomDto(int Id, string Name, string? Description)
{
    public static RoomDto FromEntity(Room room)
    {
        return new RoomDto(
            Id: room.Id,
            Name: room.Name,
            Description: room.Description);
    }
}
