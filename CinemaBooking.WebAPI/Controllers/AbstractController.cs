using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CinemaBooking.WebAPI.Controllers;

public abstract class AbstractController : ControllerBase
{
    protected IMediator Mediator { get; }

    protected AbstractController(IMediator mediator)
    {
        Mediator = mediator;
    }
}
