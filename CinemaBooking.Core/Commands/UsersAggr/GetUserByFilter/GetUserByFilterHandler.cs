using CinemaBooking.Core.Dtos.UsersAggr;
using CinemaBooking.Infrastructure.Repositories.Abstract;
using MediatR;

namespace CinemaBooking.Core.Commands.UsersAggr.GetUserByFilter;

public class GetUserByFilterHandler : IRequestHandler<GetUserByFilterCommand, UserDto>
{
    private readonly IUsersRepository _usersRepository;

    public GetUserByFilterHandler(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public async Task<UserDto?> Handle(GetUserByFilterCommand request, CancellationToken cancellationToken)
    {
        var user = _usersRepository.Get(request.ToFilter());

        return user == null ? null : UserDto.FromEntity(user);
    }
}
