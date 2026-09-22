using MediatR;
using Microsoft.AspNetCore.Mvc;
using OmniReserve.Application.Rooms.Queries.GetRoomById;
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

    //El enpoind Aparece en la plantilla Swagger de manera correcta
    [HttpGet("{id}")]
    public async Task<IActionResult> GetRoom(Guid  id)
    {
        var query = new GetRoomByIdQuery {RoomId = id}; 

        var result = await _sender.Send(query); 

        return Ok(result);
    }  
}