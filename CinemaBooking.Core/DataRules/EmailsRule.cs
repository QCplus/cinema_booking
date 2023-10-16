using CinemaBooking.Core.DataRules.Abstract;

namespace CinemaBooking.Core.DataRules;

public class EmailsRule : RegexRule
{
    public EmailsRule() : base(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", "Invalid email format")
    {
    }
}
