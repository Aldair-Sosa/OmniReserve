using OmniReserve.Domain.Entities;
namespace OmniReserve.Application.Interfaces;

public interface IReservationRepository
{
    public Task <Reservation?>GetReservationWithDetailsAsync (Guid id); 
}