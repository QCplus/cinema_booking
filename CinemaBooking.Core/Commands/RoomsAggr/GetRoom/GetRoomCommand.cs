using CinemaBooking.Core.Dtos.RoomsAggr;
using MediatR;

namespace CinemaBooking.Core.Commands.RoomsAggr.GetRoom;

public record GetRoomCommand(int Id) : IRequest<RoomDto?>;