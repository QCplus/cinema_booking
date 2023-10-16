using CinemaBooking.Core.Dtos.MoviesAggr;
using MediatR;

namespace CinemaBooking.Core.Commands.MoviesAggr.GetMovie;

public record GetMovieCommand(
    int MovieId)
    : IRequest<MovieDto?>;
