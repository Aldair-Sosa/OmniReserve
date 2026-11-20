namespace OmniReserve.Application.Interfaces;

public interface IPasswordHasher
{
    string Hash(string password);
    bool Verify(string password, string passwordHash);

    bool VerifyPassword(string password, string passwordHash)
    {
        return Verify(password, passwordHash);
    }
}