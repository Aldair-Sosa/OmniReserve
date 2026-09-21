using MediatR;
using OmniReserve.Domain.Entities;

namespace OmniReserve.Application.Rooms.Commands.CreateRoom;

public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, Guid>
{

    public Task<Guid> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
    {
        var room = new Room(request.RoomNumber, request.Type, request.PricePerNight);
    
    //Simulacion aqui se guardaria en la base de datos.S
        return Task.FromResult(room.Id);
    }
}