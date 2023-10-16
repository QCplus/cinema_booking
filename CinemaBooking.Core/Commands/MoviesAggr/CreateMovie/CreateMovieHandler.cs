using CinemaBooking.Infrastructure.Repositories.Abstract;
using MediatR;

namespace CinemaBooking.Core.Commands.MoviesAggr.CreateMovie;

internal sealed class CreateMovieHandler : IRequestHandler<CreateMovieCommand, int>
{
    private readonly IMoviesRepository _moviesRepository;

    public CreateMovieHandler(IMoviesRepository moviesRepository)
    {
        _moviesRepository = moviesRepository;
    }

    public Task<int> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_moviesRepository.Create(
            request.ToEntity()
            ));
    }
}
