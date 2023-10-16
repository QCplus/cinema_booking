using System.Text.RegularExpressions;

namespace CinemaBooking.Core.DataRules.Abstract;

public abstract class RegexRule : IDataRule<string>
{
    public Regex Regex { get; }

    public string ErrorMessage { get; }

    public RegexRule(Regex regex, string errorMessage)
    {
        Regex = regex;
        ErrorMessage = errorMessage;
    }

    public RegexRule(string pattern, string errorMessage)
        : this(new Regex(pattern), errorMessage)
    {
        
    }

    public RuleValidationResult Validate(string value)
    {
        if (!Regex.IsMatch(value))
            return new()
            {
                IsSuccess = false,
                ErrorMessage = ErrorMessage
            };

        return new()
        {
            IsSuccess = true,
        };
    }
}
