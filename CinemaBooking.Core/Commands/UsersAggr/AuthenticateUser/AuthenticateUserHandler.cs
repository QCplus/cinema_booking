using CinemaBooking.Core.Dtos.UsersAggr;
using MediatR;
using CinemaBooking.Core.DataRules;
using CinemaBooking.Core.Commands.UsersAggr.GetUserByFilter;
using CinemaBooking.Core.Services.Abstract;

namespace CinemaBooking.Core.Commands.UsersAggr.AuthenticateUser;

public class AuthenticateUserHandler : IRequestHandler<AuthenticateUserCommand, UserDto>
{
    private readonly IMediator _mediator;

    private readonly EmailsRule _emailsRule;
    private readonly PhonesRule _phonesRule;

    private readonly IPasswordHasher _passHasher;

    public AuthenticateUserHandler(IMediator mediator, EmailsRule emailsRule, PhonesRule phonesRule, IPasswordHasher passHasher)
    {
        _mediator = mediator;
        _emailsRule = emailsRule;
        _phonesRule = phonesRule;
        _passHasher = passHasher;
    }

    private GetUserByFilterCommand? CreateGetCommand(string phoneOrEmail)
    {
        if (_emailsRule.Validate(phoneOrEmail).IsSuccess)
            return new GetUserByFilterCommand(Email: phoneOrEmail);
        if (_phonesRule.Validate(phoneOrEmail).IsSuccess)
            return new GetUserByFilterCommand(Phone: phoneOrEmail);
        return new GetUserByFilterCommand(Nickname: phoneOrEmail);
    }

    public async Task<UserDto?> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
    {
        var cmd = CreateGetCommand(request.PhoneOrEmail);
        if (cmd == null)
            return null;

        UserDto? user = await _mediator.Send(cmd, cancellationToken);
        if (user == null)
            return null;

        return _passHasher.Verify(request.Password, user.PasswordHash) ? user : null;
    }
}
