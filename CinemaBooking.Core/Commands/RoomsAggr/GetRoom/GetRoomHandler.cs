using CinemaBooking.Infrastructure.DbContexts;
using CinemaBooking.Core.Dtos.RoomsAggr;
using MediatR;

namespace CinemaBooking.Core.Commands.RoomsAggr.GetRoom;

public class GetRoomHandler : IRequestHandler<GetRoomCommand, RoomDto?>
{
    private readonly AppDbContext _db;

    public GetRoomHandler(AppDbContext db)
    {
        _db = db;
    }

    public async Task<RoomDto?> Handle(GetRoomCommand request, CancellationToken cancellationToken)
    {
        var room = await _db.Rooms.FindAsync(new object[] { request.Id }, cancellationToken);

        return room == null ? null : RoomDto.FromEntity(room);
    }
}
