using CinemaBooking.Core.Commands.UsersAggr.AuthenticateUser;

namespace CinemaBooking.WebAPI.Models.UsersAggr;

public class UserCredentials
{
    public string? PhoneOrEmail { get; set; }

    public string Password { get; set; } = "";

    public AuthenticateUserCommand ToAuthenticateCmd()
    {
        return new AuthenticateUserCommand(
            PhoneOrEmail: PhoneOrEmail ?? "",
            Password: Password);
    }
}
