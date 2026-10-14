using OmniReserve.Domain.ValueObjects;

namespace OmniReserve.Application.Reservations.Queries.GetReservationDetails;

public class ReservationDetailsDto
{
    public Guid Id { get; set; }
    public EmailAddress UserEmail {get;  set;}
    public string RoomNumber {get;  set;}= string.Empty;    

}