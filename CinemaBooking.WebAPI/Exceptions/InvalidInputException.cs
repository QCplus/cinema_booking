namespace CinemaBooking.WebAPI.Exceptions;

public class InvalidInputException : UserFriendlyException
{
    public KeyValuePair<string, string>[] Errors { get; }

    public InvalidInputException(KeyValuePair<string, string>[] errors)
    {
        Errors = errors;
    }

    public InvalidInputException(KeyValuePair<string, string> error)
        : this(new KeyValuePair<string, string>[] { error })
    {
        
    }

    public InvalidInputException(string propertyName, string errorMessage)
        : this(new KeyValuePair<string, string>(propertyName, errorMessage))
    {

    }
}
