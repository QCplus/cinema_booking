using CinemaBooking.Core.Dtos.MovieSessionsAggr;
using CinemaBooking.Infrastructure.Repositories.Abstract;
using MediatR;

namespace CinemaBooking.Core.Commands.MovieSessionsAggr.GetUpcoming;

internal sealed class GetUpcomingHandler : IRequestHandler<GetUpcomingCommand, IEnumerable<UpcomingSessionDto>>
{
    private readonly IMovieSessionsRepository _movieSessionsRepository;

    public GetUpcomingHandler(IMovieSessionsRepository movieSessionsRepository)
    {
        _movieSessionsRepository = movieSessionsRepository;
    }

    public Task<IEnumerable<UpcomingSessionDto>> Handle(GetUpcomingCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(
             UpcomingSessionDto.From(_movieSessionsRepository.GetUpcoming(request.Count))
             );
    }
}
