using MediatR;
using OmniReserve.Application.Interfaces;

namespace OmniReserve.Application.Rooms.Queries.GetRoomById;

public  class GetRoomByIdQueryHandler : IRequestHandler<GetRoomByIdQuery, RoomResponseDto>
{
     private readonly IRoomRepository _rooomRepository; 

     public GetRoomByIdQueryHandler(IRoomRepository roomRepository)
    {
        _rooomRepository = roomRepository; 
    }

    public async Task <RoomResponseDto> Handle (GetRoomByIdQuery request, CancellationToken cancellationToken)
    {
        var room = await _rooomRepository.GetByIdAsync(request.RoomId);

        if (room is null)
        throw new Exception("Habitacion no encontrada"); 

        var response = new RoomResponseDto(
            room.Id,
            room.RoomNumber,
            room.Type.ToString(),
            room.PricePerNight,
            room.IsAvailable
        );

        return response; 
    }
}