namespace CinemaBooking.Core.Services.Abstract;

public interface IPasswordHasher
{
    public bool Verify(string password, string hash);

    public string GenerateHash(string password);
}
