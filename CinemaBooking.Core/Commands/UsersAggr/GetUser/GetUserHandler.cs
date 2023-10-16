using CinemaBooking.Core.Dtos.UsersAggr;
using CinemaBooking.Infrastructure.Repositories.Abstract;
using MediatR;

namespace CinemaBooking.Core.Commands.UsersAggr.GetUser;

public class GetUserHandler : IRequestHandler<GetUserCommand, UserDto?>
{
    private readonly IUsersRepository _usersRepository;

    public GetUserHandler(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public async Task<UserDto?> Handle(GetUserCommand request, CancellationToken cancellationToken)
    {
        var user = _usersRepository.GetById(request.UserId);

        return user == null ? null : UserDto.FromEntity(user);
    }
}
