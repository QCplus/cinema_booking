using CinemaBooking.Core.Services.Abstract;

namespace CinemaBooking.Core.Services;

internal class PasswordHasher : IPasswordHasher
{
    public string GenerateHash(string password)
    {
        return password;
    }

    public bool Verify(string password, string hash) => GenerateHash(password) == hash;
}
