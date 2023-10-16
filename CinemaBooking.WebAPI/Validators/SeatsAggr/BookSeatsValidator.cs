using CinemaBooking.WebAPI.Models.SeatsAggr;
using FluentValidation;

namespace CinemaBooking.WebAPI.Validators.SeatsAggr;

public class BookSeatsValidator : AbstractValidator<BookSeatsModel>
{
    public BookSeatsValidator()
    {
        RuleFor(x => x.PaymentToken).NotEmpty().WithMessage("Payment isn't completed");
        RuleFor(x => x.SeatIndecies).NotEmpty().WithMessage("Choose seat");
    }
}
