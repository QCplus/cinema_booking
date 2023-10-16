using CinemaBooking.Core.Dtos.UsersAggr;
using CinemaBooking.Infrastructure.SearchFilters.AppUsersAggr;
using MediatR;

namespace CinemaBooking.Core.Commands.UsersAggr.SearchUsers;

public record SearchUsersCommand(
    string? FirstName = null,
    string? LastName = null,
    string? Phone = null,
    string? Email = null,
    int? RoleId = null
    ) : IRequest<IEnumerable<UserDto>>
{
    public AppUsersFilter ToFilter()
        => new(
            FirstName: FirstName,
            LastName: LastName,
            Phone: Phone,
            Email: Email,
            RoleId: RoleId);
}
