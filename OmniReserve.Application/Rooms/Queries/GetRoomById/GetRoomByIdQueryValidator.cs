using System.IO.Compression;
using FluentValidation;

namespace OmniReserve.Application.Rooms.Queries.GetRoomById;

public class GetRoomByIdQueryValidator : AbstractValidator <GetRoomByIdQuery>
{
    //Se agrego bien la validacion 
    public GetRoomByIdQueryValidator ()
    {
        RuleFor(x => x.RoomId)
        .NotEmpty().WithMessage("El identificador de la habitacion es obligatorio.");
    }
}