using CinemaBooking.Core.Commands.UsersAggr.SearchUsers;

namespace CinemaBooking.WebAPI.Models.UsersAggr;

public record UsersFilter(
    string? FirstName = null,
    string? LastName = null,
    string? Phone = null,
    string? Email = null,
    int? RoleId = null)
{
    public SearchUsersCommand ToSearchCmd()
        => new(
            FirstName: FirstName,
            LastName: LastName,
            Phone: Phone,
            Email: Email,
            RoleId: RoleId);    
}
