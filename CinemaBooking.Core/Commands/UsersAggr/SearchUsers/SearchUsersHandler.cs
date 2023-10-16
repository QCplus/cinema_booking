using CinemaBooking.Core.Dtos.UsersAggr;
using CinemaBooking.Infrastructure.Repositories.Abstract;
using MediatR;

namespace CinemaBooking.Core.Commands.UsersAggr.SearchUsers;

public class SearchUsersHandler : IRequestHandler<SearchUsersCommand, IEnumerable<UserDto>>
{
    private readonly IUsersRepository _usersRepository;

    public SearchUsersHandler(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public async Task<IEnumerable<UserDto>> Handle(SearchUsersCommand request, CancellationToken cancellationToken)
    {
        return UserDto.FromEntities(
            _usersRepository.Search(request.ToFilter())
            );
    }
}
