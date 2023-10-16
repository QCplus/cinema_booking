using CinemaBooking.Core.Commands.RoomsAggr.CreateRoom;
using CinemaBooking.Core.Commands.RoomsAggr.GetRoom;
using CinemaBooking.Core.Dtos.RoomsAggr;
using CinemaBooking.WebAPI.Models.RoomsAggr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CinemaBooking.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class RoomsController : AbstractController
{
    public RoomsController(IMediator mediator) : base(mediator) { }

    [HttpGet("{id}")]
    public async Task<ActionResult<RoomModel?>> Get(int id)
    {
        RoomDto? dto = await Mediator.Send(new GetRoomCommand(id));

        return RoomModel.FromDto(dto);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(RoomPostModel newRoom)
    {
        var cmd = new CreateRoomCommand(
            Name: newRoom.Name,
            Description: newRoom.Description,
            CreatorUserId: 1
        );

        var roomId = await Mediator.Send(cmd);

        return roomId;
    }
}
