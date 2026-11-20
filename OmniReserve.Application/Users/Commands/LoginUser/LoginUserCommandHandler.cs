using OmniReserve.Application.Interfaces;
using OmniReserve.Domain.ValueObjects;
namespace OmniReserve.Application.Users.Commands.LoginUser;

public class LoginUserCommandHandler
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwProvider _jwtProvider;

    public LoginUserCommandHandler(IUserRepository userRepositry, IPasswordHasher passwordHasher, 
        IJwProvider jwProvider)
    {
        _userRepository = userRepositry;
        _passwordHasher = passwordHasher;
        _jwtProvider = jwProvider;
    }

    public async Task<string> Handle(LoginUserCommand command, CancellationToken cancellationToken)
    {

    var emailAddress = new EmailAddress(command.email); 

    var user = await _userRepository.GetByEmailAsync(emailAddress, cancellationToken);

    if(user is null)
        {
            throw new Exception("Credenciales invalidas");
        }

    bool isValidPassword = _passwordHasher.VerifyPassword(command.Password, user.PasswordHash);     
      
    if (!isValidPassword)
        {
            throw new Exception("Credenciales inválidas.");
        }

        // 6. Generación del Token (Éxito)
        string token = _jwtProvider.Generate(user);

        return token;
    }
}