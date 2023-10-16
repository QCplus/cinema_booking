using CinemaBooking.WebAPI.Models.SeatsAggr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CinemaBooking.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class SeatsController : AbstractController
{
    public SeatsController(IMediator mediator) : base(mediator)
    { }

    [HttpPost("book")]
    public async Task<ActionResult> BookSeats(BookSeatsModel model)
    {


        return Ok();
    }
}
