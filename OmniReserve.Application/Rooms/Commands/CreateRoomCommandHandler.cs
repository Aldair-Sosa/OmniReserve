using MediatR;
using OmniReserve.Domain.Entities;

namespace OmniReserve.Application.Rooms.Commands.CreateRoom;

public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, Guid>
{

    //El programa compilo de manera correcta.
    public Task<Guid> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
    {
        var room = new Room(request.RoomNumber, request.Type, request.PricePerNight);
    
        return Task.FromResult(room.Id);
    }
}