using OmniReserve.Domain.Entities;

namespace OmniReserve.Application.Interfaces; 

public interface IRoomRepository
{
    public Task AddAsync (Room room); 

    public Task<Room?> GetByIdAsync (Guid Id);
}