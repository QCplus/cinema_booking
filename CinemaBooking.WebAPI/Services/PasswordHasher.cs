using CinemaBooking.WebAPI.Services.Abstract;

namespace CinemaBooking.WebAPI.Services;

public class PasswordHasher : IPasswordHasher
{
    public string Hash(string password)
    {
        throw new NotImplementedException();
    }

    public bool VerifyPassword(string password, string hash)
    {
        throw new NotImplementedException();
    }
}
