
using OmniReserve.Domain.Exceptions;

namespace OmniReserve.Domain.Exceptions;

public class InvalidReservationDatesException : DomainException
{
    public InvalidReservationDatesException(DateTime startDate, DateTime endDate) : base($"La fecha del Check-out debe ser posterios a la fecha del  check-in")
    {
    }
}