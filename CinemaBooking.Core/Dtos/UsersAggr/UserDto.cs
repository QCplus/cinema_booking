using CinemaBooking.Infrastructure.Entities;

namespace CinemaBooking.Core.Dtos.UsersAggr;

public record UserDto(
    int Id,
    string FirstName,
    string LastName,
    string Phone,
    string? Email,
    int RoleId,
    string PasswordHash)
{
    public static UserDto FromEntity(AppUser user)
    {
        return new UserDto(
            Id: user.Id,
            FirstName: user.FirstName,
            LastName: user.LastName,
            Phone: user.Phone,
            Email: user.Email,
            RoleId: user.RoleId,
            PasswordHash: user.PasswordHash
            );
    }

    public static IEnumerable<UserDto> FromEntities(IEnumerable<AppUser> users)
        => users.Select(u => FromEntity(u));
}