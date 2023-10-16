namespace CinemaBooking.Infrastructure.Entities;

public class AppUser : BaseEntity
{
    public string FirstName { get; set; } = "";

    public string LastName { get; set; } = "";

    public string Phone { get; set; } = "";

    public string? Email { get; set; }

    public int RoleId { get; set; }

    public string PasswordHash { get; set; } = "";

    public string? Nickname { get; set; }
}
