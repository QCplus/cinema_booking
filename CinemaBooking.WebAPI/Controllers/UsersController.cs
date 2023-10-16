using CinemaBooking.Core.Commands.UsersAggr.GetUser;
using CinemaBooking.WebAPI.Models.UsersAggr;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaBooking.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class UsersController : AbstractController
{
    public UsersController(IMediator mediator) : base(mediator) { }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserModel?>> GetUserById(int id)
    {
        var user = await Mediator.Send(new GetUserCommand(id));

        return user == null ? null : UserModel.FromDto(user);
    }

    [HttpGet]
    public async Task<ActionResult<UserModel[]>> GetUsers([FromQuery] UsersFilter filter)
        => UserModel.FromDtos(
            await Mediator.Send(filter.ToSearchCmd())
            ).ToArray();

    [HttpPost]
    public async Task<ActionResult<int>> Create(UserModel user)
    {
        throw new NotImplementedException();
    }
}
