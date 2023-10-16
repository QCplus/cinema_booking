using CinemaBooking.Core.Commands.MovieSessionsAggr.GetUpcoming;
using CinemaBooking.WebAPI.Models.MovieSessionsAggr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CinemaBooking.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieSessionsController : AbstractController
{
    public MovieSessionsController(IMediator mediator) : base(mediator)
    { }

    [HttpPost]
    public async Task<ActionResult> Create(MovieSessionsPostModel model)
    {
        await Mediator.Send(model.ToCmd());

        return Ok();
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MovieSessionModel>>> Search([FromQuery] MovieSessionsFilter filter)
    {
        var sessions = await Mediator.Send(filter.ToCmd());

        return MovieSessionModel.From(sessions).ToList();
    }

    [HttpGet("upcoming/{count}")]
    public async Task<ActionResult<IEnumerable<UpcomingSessionModel>>> GetUpcoming(int count)
    {
        var sessions = await Mediator.Send(new GetUpcomingCommand(count));

        return UpcomingSessionModel.FromDtos(sessions).ToList();
    }
}
