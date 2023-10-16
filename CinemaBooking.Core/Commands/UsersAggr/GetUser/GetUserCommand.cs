using CinemaBooking.Core.Dtos.UsersAggr;
using MediatR;

namespace CinemaBooking.Core.Commands.UsersAggr.GetUser;

public record class GetUserCommand(int UserId) : IRequest<UserDto?>;