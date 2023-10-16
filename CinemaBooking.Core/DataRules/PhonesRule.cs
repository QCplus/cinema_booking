using CinemaBooking.Core.DataRules.Abstract;

namespace CinemaBooking.Core.DataRules;

public class PhonesRule : RegexRule
{
    public PhonesRule() : base("^[0-9]{11}$", "Invalid phone number format")
    {
    }
}
