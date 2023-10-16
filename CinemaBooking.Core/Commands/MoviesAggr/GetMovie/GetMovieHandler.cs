using CinemaBooking.Core.Dtos.MoviesAggr;
using CinemaBooking.Infrastructure.Repositories.Abstract;
using MediatR;

namespace CinemaBooking.Core.Commands.MoviesAggr.GetMovie;

internal sealed class GetMovieHandler : IRequestHandler<GetMovieCommand, MovieDto?>
{
    private readonly IMoviesRepository _moviesRepository;

    public GetMovieHandler(IMoviesRepository moviesRepository)
    {
        _moviesRepository = moviesRepository;
    }

    public Task<MovieDto?> Handle(GetMovieCommand request, CancellationToken cancellationToken)
    {
        var movie = _moviesRepository.GetById(request.MovieId);

        return Task.FromResult(
            movie == null ? null : MovieDto.FromEntity(movie)
            );
    }
}
