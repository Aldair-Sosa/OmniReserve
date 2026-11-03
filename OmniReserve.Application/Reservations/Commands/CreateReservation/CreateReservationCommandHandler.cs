using OmniReserve.Application.Interfaces;
using OmniReserve.Domain.Entities;
 using MediatR;

namespace OmniReserve.Application.Reservations.Commands.CreateReservation;

public class CreateReservationCommandHandler
{
    private readonly IReservationRepository _reservationRepository;

    private readonly IRoomRepository _roomRepository; 


    public record CreateReservationCommand(Guid RoomId, Guid UserId, DateTime StartDate, DateTime EndDate, decimal TotalPrice) : IRequest<Guid>;

    public CreateReservationCommandHandler (IReservationRepository reservationRepository, IRoomRepository roomRepository)
    {
        _reservationRepository = reservationRepository;
        _roomRepository = roomRepository;
    }
    
    // La implementación del método Handle es correcta y no presenta errores de compilación.
    public async Task<Guid> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
        
            bool isAvailable = await _reservationRepository.IsRoomAvailableAsync(request.RoomId, request.StartDate, request.EndDate);
            
            if (!isAvailable)
            {
                throw new Exception("La habitación seleccionada ya está ocupada en el rango de fechas solicitado.");
            }

            
            var reservation = new Reservation(
                request.RoomId,
                request.UserId,
                request.StartDate,
                request.EndDate,
                request.TotalPrice
            );

            await _reservationRepository.AddAsync(reservation);

            return reservation.Id;
        }
}


