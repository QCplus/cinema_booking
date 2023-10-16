using CinemaBooking.Core.Dtos.UsersAggr;
using CinemaBooking.Infrastructure.SearchFilters.AppUsersAggr;
using MediatR;

namespace CinemaBooking.Core.Commands.UsersAggr.GetUserByFilter;

public record GetUserByFilterCommand(
    string? Phone = null,
    string? Email = null,
    string? Nickname = null
    ) : IRequest<UserDto>
{
    public SingleAppUserFilter ToFilter()
        => new (
            Email: Email,
            Phone: Phone,
            Nickname: Nickname);
}
