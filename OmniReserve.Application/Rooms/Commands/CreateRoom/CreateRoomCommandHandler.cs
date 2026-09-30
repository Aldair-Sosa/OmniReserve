using MediatR;
using OmniReserve.Domain.Entities;
using  OmniReserve.Application.Interfaces;

namespace OmniReserve.Application.Rooms.Commands.CreateRoom;

public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, Guid>
{

     private readonly IRoomRepository _roomRepository;

    public CreateRoomCommandHandler(IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository;
    }

    public async Task<Guid> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
    {
        var room = new Room(
            request.RoomNumber,
            request.Type,
            request.PriceNight
        );

        await _roomRepository.AddAsync(room);

        return room.Id;
    }
}