using MediatR;
using OmniReserve.Domain.Enums;

namespace OmniReserve.Application.Users.Commands.CrateUser;
public record CreateUserCommand(
    string FirstName,
        string LastName,
        string Email,
        string Password,
        Role Role
) : IRequest<Guid>;
