using OmniReserve.Domain.Entities;
namespace OmniReserve.Application.Interfaces;

public interface IReservationRepository
{
    public Task AddAsync (Reservation reservation);
    public Task <Reservation?>GetReservationWithDetailsAsync (Guid id); 

    public Task<bool> IsRoomAvailableAsync (Guid roomId, DateTime start, DateTime end);
}