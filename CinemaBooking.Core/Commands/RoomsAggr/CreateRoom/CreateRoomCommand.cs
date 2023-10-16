using MediatR;

namespace CinemaBooking.Core.Commands.RoomsAggr.CreateRoom;

public record CreateRoomCommand(string Name, string? Description, int CreatorUserId) : IRequest<int>;
