using MediatR;
using OmniReserve.Application.Interfaces;
using OmniReserve.Domain.ValueObjects;
using OmniReserve.Domain.Entities;

namespace OmniReserve.Application.Users.Commands.CrateUser;
public class CreateUserCommandHanldler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;

    public CreateUserCommandHanldler(IUserRepository userRepository, IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task <Guid> Handle(CreateUserCommand request, CancellationToken cancellattionToken)
    {
        var email = new EmailAddress(request.Email); 

        string secureHash = _passwordHasher.Hash(request.Password);

        var user = new User(
          request.FirstName,
                request.LastName,
                new EmailAddress(request.Email),
                secureHash,
                request.Role
        );    

        await _userRepository.AddAsync(user);   
        return user.Id;
    }

}