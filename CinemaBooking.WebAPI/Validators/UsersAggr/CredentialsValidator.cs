using CinemaBooking.WebAPI.Models.UsersAggr;
using FluentValidation;

namespace CinemaBooking.WebAPI.Validators.UsersAggr;

public class CredentialsValidator : AbstractValidator<UserCredentials>
{
    public CredentialsValidator()
    {
        RuleFor(x => x.PhoneOrEmail).NotEmpty().WithMessage("Phone or email must be specified");
        RuleFor(x => x.Password).NotEmpty().WithMessage("Password must be specified");
    }
}
