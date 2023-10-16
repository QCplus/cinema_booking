using CinemaBooking.Infrastructure.Repositories.Abstract;
using MediatR;

namespace CinemaBooking.Core.Commands.MovieSessionsAggr.CreateSessions;

internal sealed class CreateSessionsHandler : IRequestHandler<CreateSessionsCommand>
{
    private readonly IMovieSessionsRepository _movieSessionsRepository;

    public CreateSessionsHandler(IMovieSessionsRepository movieSessionsRepository)
    {
        _movieSessionsRepository = movieSessionsRepository;
    }

    public Task Handle(CreateSessionsCommand request, CancellationToken cancellationToken)
    {
        _movieSessionsRepository.Create(
            startsFrom: request.StartsFrom,
            endsAt: request.EndsAt,
            days: request.Days,
            movieStarts: request.MovieStarts,
            movieId: request.MovieId,
            roomId: request.RoomId,
            price: request.Price);

        return Task.CompletedTask;
    }
}
