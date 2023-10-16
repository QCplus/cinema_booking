using CinemaBooking.Infrastructure.DbContexts;
using CinemaBooking.Infrastructure.Entities;
using MediatR;

namespace CinemaBooking.Core.Commands.RoomsAggr.CreateRoom;

public sealed class CreateRoomHandler : IRequestHandler<CreateRoomCommand, int>
{
    private readonly AppDbContext _db;

    public CreateRoomHandler(AppDbContext db)
    {
        _db = db;
    }

    public async Task<int> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
    {
        Room newRoom = new()
        {
            Name = request.Name,
            Description = request.Description
        };

        _db.Rooms.Add(newRoom);
        _db.SaveChanges();

        return newRoom.Id;
    }
}
