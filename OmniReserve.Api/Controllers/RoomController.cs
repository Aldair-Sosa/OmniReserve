using MediatR;
using Microsoft.AspNetCore.Mvc;
using OmniReserve.Application.Rooms.Commands;
using OmniReserve.Application.Rooms.Commands.CreateRoom;

namespace OmniReserve.Api.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class RoomController : ControllerBase
{
    private readonly ISender _sender; 
    
    public RoomController (ISender sender)
    {
        _sender = sender; 
    }

    [HttpPost]
    public async Task <IActionResult> Create (CreateRoomCommand command)
    {
        var productId = await _sender.Send(command);

        return Ok(productId);
    }
}