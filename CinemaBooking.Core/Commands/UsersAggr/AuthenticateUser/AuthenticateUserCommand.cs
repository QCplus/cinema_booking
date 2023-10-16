using CinemaBooking.Core.Dtos.UsersAggr;
using MediatR;

namespace CinemaBooking.Core.Commands.UsersAggr.AuthenticateUser;

public record AuthenticateUserCommand(
    string Password,
    string PhoneOrEmail
    ) : IRequest<UserDto>;
