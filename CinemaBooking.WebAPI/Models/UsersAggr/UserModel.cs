using CinemaBooking.Core.Dtos.UsersAggr;

namespace CinemaBooking.WebAPI.Models.UsersAggr;

public class UserModel
{
    public int Id { get; set; }

    public string FirstName { get; set; } = "";

    public string LastName { get; set; } = "";

    public string FullName => $"{FirstName} {LastName}";

    public string Phone { get; set; } = "";

    public string? Email { get; set; } = "";

    public int RoleId { get; set; }

    public static UserModel FromDto(UserDto dto)
    {
        return new UserModel()
        {
            Id = dto.Id,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Phone = dto.Phone,
            Email = dto.Email,
            RoleId = dto.RoleId,
        };
    }

    public static IEnumerable<UserModel> FromDtos(IEnumerable<UserDto> dtos)
        => dtos.Select(u => FromDto(u));
}
