
namespace OmniReserve.Application.Rooms.Commands.CreateRoom;

public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, Guid>
{
    
    public async Task<Guid> Handle(CreateRoomCommand request)
    {
        var room = new Room(request.RoomNumber, request.Type, request.PricePerNight);
        await Task.Delay(100); 

        return room.Id;
    }
}