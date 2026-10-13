using OmniReserve.Domain.Entities;

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

    public async Task<Reservation?> GetReservationWithDetailsAsync(Guid id)
    {
        return await _context.Reservations
            .Include(r => r.User)
            .Include(r => r.Room)
            .FirstOrDefaultAsync(r => r.Id == id); 
    }


}