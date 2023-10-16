namespace CinemaBooking.WebAPI.Exceptions;

public class UserFriendlyException : Exception
{
    public UserFriendlyException()
    {
    }

    public UserFriendlyException(string? message) : base(message)
    {
    }
}
