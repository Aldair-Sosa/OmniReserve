
using OmniReserve.Domain.Exceptions;

namespace OmniReserve.Domain.Exceptions; 

public class RoomNotAvailableException : DomainException
{
    public RoomNotAvailableException (string roomNumber) : base($"La habitacion {roomNumber} no esta disponible en este momento.")
    {
    }
}