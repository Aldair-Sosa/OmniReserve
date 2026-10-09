using Microsoft.EntityFrameworkCore;
using OmniReserve.Application.Interfaces;
using OmniReserve.Domain.Entities;
namespace OmniReserve.Infrastructure.Peristence.Repositories;

public class RoomRepository : IRoomRepository
{
    //La clase se agrego de forma correcta 

    private readonly ApplicationDbContext _context;

    public RoomRepository(ApplicationDbContext context)
    {
        _context = context;
    }
  
    public async Task AddAsync (Room room)
    {
        
        await _context.Rooms.AddAsync(room);
        await _context.SaveChangesAsync();
    }

    public async Task<Room?> GetByIdAsync (Guid Id)
    {
        return await _context.Rooms.FirstOrDefaultAsync(r => r.Id == Id);
    }

    public async Task<Room?> SearchByNumberAsync (string roomNumber)
    {
        return await _context.Rooms
        .FirstOrDefaultAsync(r => r.RoomNumber == roomNumber);
    }
}