using CinemaBooking.Core.Commands.MoviesAggr.GetMovie;
using CinemaBooking.WebAPI.Models.MoviesAggr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CinemaBooking.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MoviesController : AbstractController
{
    public MoviesController(IMediator mediator) : base(mediator)
    { }

    [HttpGet("{id}")]
    public async Task<ActionResult<MovieModel?>> Get(int id)
    {
        var movie = await Mediator.Send(new GetMovieCommand(id));

        return movie == null ? null : MovieModel.FromDto(movie);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(MoviePostModel model)
    {
        return await Mediator.Send(model.ToCmd());
    }
}
