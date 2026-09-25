using OmniReserve.Application.Interfaces;
using OmniReserve.Domain.Entities;
namespace OmniReserve.Infrastructure.Peristence.Repositories;

public class RoomRepository : IRoomRepository
{
    //La clase se agrego de forma correcta 
    private static readonly Dictionary<Guid, Room> _rooms = new();
    public Task AddAsync (Room room)
    {
        _rooms [room.Id] = room; 

        return Task.CompletedTask;
    }

    public Task<Room?>  GetByIdAsync (Guid Id)
    {
        _rooms.TryGetValue(Id, out var room); 
        return Task.FromResult(room);
    }
}