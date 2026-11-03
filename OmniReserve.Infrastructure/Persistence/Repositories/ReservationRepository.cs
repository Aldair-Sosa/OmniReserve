using OmniReserve.Domain.Entities;
using MediatR;
using OmniReserve.Application.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace OmniReserve.Infrastructure.Persistence.Repositories;
//La clase se agrego de forma correcta y no hay errores de compilacin
public class ReservationRepository : IReservationRepository
{
    private readonly ApplicationDbContext  _context; 

    public ReservationRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task  AddAsync (Reservation reservation)
    {
         await _context.Reservations.AddAsync(reservation); 
         await _context.SaveChangesAsync();

    }
// 
    public async Task<Reservation?> GetReservationWithDetailsAsync(Guid id)
    {
        return await _context.Reservations
            .Include(r => r.User)
            .Include(r => r.Room)
            .FirstOrDefaultAsync(r => r.Id == id); 
    }

    //El proyecto compila de manera correcta 
    public async Task<bool> IsRoomAvailableAsync (Guid roomId, DateTime start, DateTime end)
    {
        return await _context.Reservations
        .AnyAsync(r => r.Id ==  roomId && r.CheckInDate < end && r.CheckOutDate > start);
    }

}