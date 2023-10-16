namespace CinemaBooking.Core.DataRules.Abstract;

public class RuleValidationResult
{
    public bool IsSuccess { get; set; }

    public string? ErrorMessage { get; set; }
}

public interface IDataRule<T>
{
    public RuleValidationResult Validate(T value);
}
