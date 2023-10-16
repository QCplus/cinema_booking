namespace CinemaBooking.WebAPI.Services.Abstract;

public interface IPasswordHasher
{
    public string Hash(string password);

    public bool VerifyPassword(string password, string hash);
}
